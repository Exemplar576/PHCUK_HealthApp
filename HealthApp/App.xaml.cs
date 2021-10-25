using HealthApp.Views;
using Xamarin.Forms;

namespace HealthApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new SplashPage(true);
        }
        protected override void OnStart()
        {
        }
        protected override void OnSleep()
        { 
        }
        protected async override void OnResume()
        {
            await MainPage.Navigation.PushModalAsync(new SplashPage(false));
        }
    }
}
