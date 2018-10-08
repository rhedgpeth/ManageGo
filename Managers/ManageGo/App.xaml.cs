using System.Threading.Tasks;
using ManageGo.Core;
using ManageGo.Core.Managers;
using ManageGo.Core.Managers.ViewModels;
using ManageGo.Core.Services;
using ManageGo.Pages;
using ManageGo.Services;
using Xamarin.Forms;

namespace ManageGo
{
    public partial class App : Application
    {
        ISecureStorageService _secureStorageService;
        ISecureStorageService SecureStorageService
        {
            get
            {
                if (_secureStorageService == null)
                {
                    _secureStorageService = ServiceContainer.Resolve<ISecureStorageService>();
                }

                return _secureStorageService;
            }
        }

        public App()
        {
            InitializeComponent();

            UI.Navigation.NavigationService.Initialize(typeof(WelcomePage).Assembly);

            RegisterServices();

            StartAnalyticsService();

            SubscribeToGlobalMessages();

            SetRootPage();
        }

        void StartAnalyticsService()
        {
            var analyticsService = ServiceContainer.Resolve<IAnalyticsService>();

            analyticsService.Start();
        }

        void SubscribeToGlobalMessages()
        {
            var messageService = ServiceContainer.Resolve<IMessageService>();

            if (messageService != null)
            {
                messageService.Subscribe(this, MessageType.ApiForbiddenStatus, Logout);
            }
        }

        void Logout(string message)
        {
            if (!string.IsNullOrEmpty(AppInstance.ApiAccessToken))
            {
                AppInstance.ApiAccessToken = null;

                SecureStorageService.Remove(Constants.SecureStorageKeys.AccessToken);

                Device.BeginInvokeOnMainThread(() =>
                {
                    MainPage = new NavigationPage(new LoginPage { ViewModel = new LoginViewModel() });
                });
            }

            if (!string.IsNullOrEmpty(message))
            {
                // TODO: Show toast
            }
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
            var accessToken = await SecureStorageService.GetAsync(Constants.SecureStorageKeys.AccessToken);

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
            ServiceContainer.Register<IMessageService>(() => new MessageService());
            ServiceContainer.Register<IAlertService>(() => new AlertService());
            ServiceContainer.Register<ICacheService>(() => new CacheService("ManageGo"));
            ServiceContainer.Register<IMediaService>(() => new MediaService());
            ServiceContainer.Register<IAnalyticsService>(() => new AnalyticsService());
        }
    }
}
