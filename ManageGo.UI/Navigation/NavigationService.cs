using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using ManageGo.Core.Services;
using ManageGo.Core.ViewModels;
using System.Reflection;
using ManageGo.Core;

using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using ManageGo.UI.Pages;

namespace ManageGo.UI.Navigation
{
    public interface IViewFor
    {
        object ViewModel { get; set; }
    }

    public interface IViewFor<T> : IViewFor where T : BaseNavigationViewModel
    {
        new T ViewModel { get; set; }
    }

    public class NavigationService : INavigationService
    {
        public static INavigationService Initialize(Assembly asm)
        {
            var navService = new NavigationService();
            navService.RegisterViewModels(asm);

            ServiceContainer.Register<INavigationService>(() => navService);

            return navService;
        }

        INavigation FormsNavigation
        {
            get
            {
                var tabController = Application.Current.MainPage as TabbedPage;
                var masterController = Application.Current.MainPage as MasterDetailPage;

                // First check to see if we're on a tabbed page, then master detail, finally go to overall fallback
                return tabController?.CurrentPage?.Navigation ??
                                     (masterController?.Detail as TabbedPage)?.CurrentPage?.Navigation ?? // special consideration for a tabbed page inside master/detail
                                     masterController?.Detail?.Navigation ??
                                     Application.Current.MainPage.Navigation;
            }
        }

        // View model to view lookup - making the assumption that view model to view will always be 1:1
        readonly Dictionary<Type, Type> _viewModelViewDictionary = new Dictionary<Type, Type>();

        #region Replace

        // Because we're going to do a hard switch of the page, either return
        // the detail page, or if that's null, then the current main page       
        Page DetailPage
        {
            get
            {
                var masterController = Application.Current.MainPage as MasterDetailPage;
                return masterController?.Detail ?? Application.Current.MainPage;
            }
            set
            {
                if (Application.Current.MainPage is MasterDetailPage masterController)
                {
                    masterController.Detail = value;
                    masterController.IsPresented = false;
                }
                else
                {
                    Application.Current.MainPage = value;
                }
            }
        }
        
        public async Task SetDetailView(BaseNavigationViewModel viewModel)
        {
			Page newDetailPage = await Task.Run(() =>
			{
				var view = InstantiateView(viewModel);
                            
				// Tab pages shouldn't go into navigation pages
				if (view is TabbedPage)
					newDetailPage = (Page)view;
				else
					newDetailPage = new NavigationPage((Page)view);

				return newDetailPage;
			});

            DetailPage = newDetailPage;
        }
              
        public async Task SetDetailView<T>(Action<T> initialize = null) where T : BaseNavigationViewModel
        {
			T viewModel = await Task.Run(() =>
			{
				// First instantiate the view model
				viewModel = Activator.CreateInstance<T>();
                
				initialize?.Invoke(viewModel);

				return viewModel;
			}).ConfigureAwait(false);

            // Actually switch the page
            await SetDetailView(viewModel);
        }

        public void SetRootView(BaseNavigationViewModel viewModel, bool withNavigationEnabled = true)
        {
            if (InstantiateView(viewModel) is Page view)
            {
                if (withNavigationEnabled)
                    Application.Current.MainPage = new NavigationPage(view);
                else
                    Application.Current.MainPage = view;
            }
        }

        #endregion

        #region Registration

        public void RegisterViewModels(Assembly asm)
        {
            // Loop through everything in the assembly that implements IViewFor<T>
            foreach (var type in asm.DefinedTypes.Where(dt => !dt.IsAbstract &&
                dt.ImplementedInterfaces.Any(ii => ii == typeof(IViewFor))))
            {

                // Get the IViewFor<T> portion of the type that implements it
                var viewForType = type.ImplementedInterfaces.FirstOrDefault(
                    ii => ii.IsConstructedGenericType &&
                    ii.GetGenericTypeDefinition() == typeof(IViewFor<>));

                // Register it, using the T as the key and the view as the value
                Register(viewForType.GenericTypeArguments[0], type.AsType());
            }
        }

        public void Register(Type viewModelType, Type viewType)
        {
            if (!_viewModelViewDictionary.ContainsKey(viewModelType))
                _viewModelViewDictionary.Add(viewModelType, viewType);
        }

        #endregion

        #region Pop

        public Task PopAsync() => FormsNavigation.PopAsync(true);

        public Task PopModalAsync() => FormsNavigation.PopModalAsync(true);

		public Task PopPopupAsync(bool animate = true) => FormsNavigation.PopPopupAsync(animate);

        public Task PopToRootAsync(bool animate) => FormsNavigation.PopToRootAsync(animate);

        #endregion

        #region Push

        public Task PushAsync(BaseNavigationViewModel viewModel)
        {
            var view = InstantiateView(viewModel);
            return FormsNavigation.PushAsync((Page)view);
        }

        public Task PushModalAsync(BaseNavigationViewModel viewModel)
        {
            viewModel.Type = Core.Enumerations.ViewModelType.Modal;

            var view = InstantiateView(viewModel);

            // Most likely we're going to want to put this into a navigation page so we can have a title bar on it
            var nv = new NavigationPage((Page)view);

            return FormsNavigation.PushModalAsync(nv);
        }

		public Task PushPopupAsync(BaseNavigationViewModel viewModel, bool animate = true)
        {
			viewModel.Type = Core.Enumerations.ViewModelType.Popup;

			var view = InstantiateView(viewModel);

			return FormsNavigation.PushPopupAsync((PopupPage)view);
        } 

        public Task PushAsync<T>(Action<T> initialize = null) where T : BaseNavigationViewModel
        {
            T viewModel;
            
            // Instantiate the view model & invoke the initialize method, if any
            viewModel = Activator.CreateInstance<T>();
            initialize?.Invoke(viewModel);

            return PushAsync(viewModel);
        }

        public Task PushModalAsync<T>(Action<T> initialize = null) where T : BaseNavigationViewModel
        {
            T viewModel;

            // Instantiate the view model & invoke the initialize method, if any
            viewModel = Activator.CreateInstance<T>();

			viewModel.Type = Core.Enumerations.ViewModelType.Modal;

            initialize?.Invoke(viewModel);

            return PushModalAsync(viewModel);
        }

        #endregion

        IViewFor InstantiateView(BaseNavigationViewModel viewModel)
        {
            // Figure out what type the view model is
            var viewModelType = viewModel.GetType();

            // look up what type of view it corresponds to
            var viewType = _viewModelViewDictionary[viewModelType];

            // instantiate it
            var view = (IViewFor)Activator.CreateInstance(viewType);

            view.ViewModel = viewModel;

            return view;
        }
    }
}
