using System;
using System.Diagnostics;
using System.Threading.Tasks;
using ManageGo.Core.ViewModels;
using ManageGo.UI.Navigation;
using Xamarin.Forms;

namespace ManageGo.UI.Pages
{
	public abstract class BaseContentPage : ContentPage
	{ }

    public abstract class BaseContentPage<T> : BaseContentPage, IViewFor<T> where T : BaseNavigationViewModel //, new()
    {
        T _viewModel;

        public T ViewModel
        {
            get
            {
				//if (_viewModel == null)
					//_viewModel = Activator.CreateInstance<T>();

                return _viewModel;
            }
            set
			{
				BindingContext = _viewModel = value;

				if (_viewModel != null)
				{
					Task.Run(async () =>
					{
						try
						{
							//await Task.Delay(5000);
							await _viewModel.InitAsync();
						}
						catch (Exception ex)
						{
							Debug.WriteLine(ex.Message);
						}
					});
				}
			}
        }

        object IViewFor.ViewModel
        {
            get { return _viewModel; }
            set
            {
                ViewModel = (T)value;
            }
        }

        protected BaseContentPage() : this(Color.FromHex("#F9FAFB"))
        { }

        protected BaseContentPage(Color backgroundColor)
        {
            BackgroundColor = backgroundColor;
		}

        async void Init()
        {
            await ViewModel.InitAsync();
        }
    }
}
