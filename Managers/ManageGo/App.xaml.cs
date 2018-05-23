using System.Reflection;
using ManageGo.Core.Managers.ViewModels;
using ManageGo.Pages;
using Xamarin.Forms;

namespace ManageGo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            UI.Navigation.NavigationService.Initialize(typeof(WelcomePage).Assembly);

            SetRootPage();
        }

        // TODO: Implement functionality
        bool loggedIn = true;
		//bool loggedIn = false;

        void SetRootPage()
        {
			// Mocked data
			if (loggedIn)
				MainPage = new RootPage { ViewModel = new RootViewModel() };
            else
				MainPage = new NavigationPage(new WelcomePage { ViewModel = new WelcomeViewModel() });
        }

        protected override void OnStart()
        { }

        protected override void OnSleep()
        { }

        protected override void OnResume()
        { }
    }
}
