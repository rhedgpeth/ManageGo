using System.Reflection;
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
                MainPage = new RootPage();
            else
                MainPage = new NavigationPage(new WelcomePage());
        }

        protected override void OnStart()
        { }

        protected override void OnSleep()
        { }

        protected override void OnResume()
        { }
    }
}
