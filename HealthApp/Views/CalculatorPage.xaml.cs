using HealthApp.Models;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HealthApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalculatorPage : ContentPage
    {
        public CalculatorPage()
        {
            InitializeComponent();
        }
        protected async void OnCalculate(object sender, EventArgs e)
        {
            float spoonCount = 1;
            foreach (Entry box in new Entry[] { GI, SS, Carbs })
            {
                if (string.IsNullOrEmpty(box.Text) || !int.TryParse(box.Text, out int value))
                {
                    box.Text = null;
                    box.PlaceholderColor = Color.Red;
                    await Shake(box);
                    return;
                }
                else
                {
                    spoonCount *= value;
                }
            }

            await Navigation.PushAsync(new SugarDetail(new Tiles()
            {
                Name = "Calculation",
                Image = ImageSource.FromFile("upload.png"),
                GlycaemicIndex = int.Parse(GI.Text),
                ServeSize = int.Parse(SS.Text),
                SpoonCount = spoonCount / 27300F,
                Type = "User Created",
                ItemType = "Calculated"
            }));
        }
        protected void OnClear(object sender, EventArgs e)
        {
            foreach (Entry box in new Entry[] { GI, SS, Carbs })
            {
                box.Text = null;
                box.PlaceholderColor = Color.Default;
            }
        }
        private async Task Shake(Entry entry)
        {
            for (int i = 15; i > 0; i -= 5)
            {
                await entry.TranslateTo(-i, 0, 50);
                await entry.TranslateTo(i, 0, 50);
            }
            entry.TranslationX = 0;
        }
    }
}