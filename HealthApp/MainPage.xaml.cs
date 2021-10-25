using Xamarin.Forms;

namespace HealthApp
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            CurrentPage = Children[1];
        }
    }
}
