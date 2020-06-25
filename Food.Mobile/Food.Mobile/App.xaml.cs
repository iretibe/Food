using Food.Mobile.Pages;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Food.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var accesstoken = Preferences.Get("accessToken", string.Empty);
            if (string.IsNullOrEmpty(accesstoken))
            {
                MainPage = new NavigationPage(new SignupPage());
            }
            else
            {
                MainPage = new NavigationPage(new HomePage());
            }
            //MainPage = new MainPage();
            //MainPage = new NavigationPage(new SignupPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
