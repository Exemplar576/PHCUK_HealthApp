using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HealthApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashPage : ContentPage
    {
        private bool ShowPage;
        public SplashPage(bool ShowPage)
        {
            InitializeComponent();
            this.ShowPage = ShowPage;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await bannerView.FadeTo(1, 1000);
            _ = ShowPage ? Application.Current.MainPage = new MainPage() : await Navigation.PopModalAsync();
        }
    }
}