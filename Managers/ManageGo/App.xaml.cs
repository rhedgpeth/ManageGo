using System.Threading.Tasks;
using ManageGo.Core;
using ManageGo.Core.Managers;
using ManageGo.Core.Managers.ViewModels;
using ManageGo.Core.Services;
using ManageGo.Pages;
using ManageGo.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ManageGo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            RegisterServices();

            UI.Navigation.NavigationService.Initialize(typeof(WelcomePage).Assembly);

            SetRootPage();
        }

        async void SetRootPage()
        {
			if (await IsLoggedIn())
				MainPage = new RootPage { ViewModel = new RootViewModel() };
            else
				MainPage = new NavigationPage(new WelcomePage { ViewModel = new WelcomeViewModel() });
        }

        async Task<bool> IsLoggedIn()
        {
            var accessToken = await SecureStorage.GetAsync(Core.Managers.Constants.SecureStorageKeys.AccessToken);

            if (!string.IsNullOrEmpty(accessToken))
            {
                AppInstance.ApiAccessToken = accessToken;

                return true;
            }

            return false;
        }

        void RegisterServices()
        {
            ServiceContainer.Register<ISecureStorageService>(() => new SecureStorageService());
        }
    }
}
