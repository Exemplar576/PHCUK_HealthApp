using HealthApp.Services;
using Xamarin.Forms;

namespace HealthApp.ViewModels
{
    class AboutViewModel : BaseViewModel
    {
        private HtmlWebViewSource _Source;
        public HtmlWebViewSource Source
        {
            get
            {
                return _Source;
            }
            set
            {
                _Source = value;
                SetPropertyValue(ref _Source, value, "Source");
            }
        }
        public AboutViewModel()
        {
            ILocalDataService BasePath = DependencyService.Get<ILocalDataService>();
            Source = new HtmlWebViewSource()
            {
                BaseUrl = BasePath.Path(),
                Html = BasePath.Data()
            };
        }
    }
}
