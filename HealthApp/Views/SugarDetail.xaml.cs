using HealthApp.Models;
using HealthApp.Services;
using HealthApp.ViewModels;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HealthApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SugarDetail : ContentPage
    {
        private readonly Tiles Tile;
        private void UpdateUI() => (BindingContext as SugarDetailViewModel).Tile = Tile;
        public SugarDetail(Tiles tile)
        {
            InitializeComponent();
            Tile = tile;
            UpdateUI();
            GenerateMenuItems();
            OnStart();
        }
        private void GenerateMenuItems()
        {
            switch (Tile.ItemType)
            {
                case "Calculated":
                    Tile.Image = null;
                    ImageView.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(AddImage), NumberOfTapsRequired = 1 });
                    ToolbarItems.Add(new ToolbarItem()
                    {
                        Text = "Save Item",
                        Command = new Command(SaveItem),
                        IconImageSource = ImageSource.FromFile("saveSymbol.png")
                    });
                    break;
                case "Saved":
                    ToolbarItems.Add(new ToolbarItem()
                    {
                        Text = "Delete Item",
                        Command = new Command(DeleteItem),
                        IconImageSource = ImageSource.FromFile("deleteSymbol.png")
                    });
                    break;
                default:
                    break;
            }
        }
        private async void OnStart()
        {
            StackLayout stack;
            ImageSource image = ImageSource.FromFile("spoon.png");
            float count = Tile.SpoonCount;
            for (int i = 0; i < Math.Ceiling(Tile.SpoonCount / 4F); i++)
            {
                stack = new StackLayout() { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.CenterAndExpand };

                for (int e = 0; e < (Tile.SpoonCount > 4 ? 4 : count); e++)
                {
                    stack.Children.Add(new Image() { Source = image, Opacity = 0 });
                }
                MainView.Children.Add(stack);

                foreach (View e in stack.Children)
                {
                    await e.FadeTo(count > 1 ? 1 : count, (uint)(3000F / Tile.SpoonCount), Easing.Linear);
                    count--;
                }
            }
        }
        private async void AddImage()
        {
            Stream image = await DependencyService.Get<IImageService>().GetImageAsync();
            if (image != null)
            {
                BinaryReader reader = new BinaryReader(image);
                byte[] buffer = reader.ReadBytes((int)image.Length);
                reader.Close();
                Tile.Image = ImageSource.FromStream(() => new MemoryStream(buffer));
                UpdateUI();
            }
        }
        private async void SaveItem()
        {
            string name = await DisplayPromptAsync("Save Item?", "Please enter a name: ", "Confirm", "Cancel", null, 30);
            if (!string.IsNullOrEmpty(name))
            {
                Tile.Name = name;
                Tile.ItemType = "Saved";
                UpdateUI();
                MessagingCenter.Send(this, "AddItem", Tile);
                ImageView.GestureRecognizers.Clear();
                ToolbarItems.Clear();
                await DisplayAlert("Item Saved", $"The item {name} has been added to the database.", "Ok");
            }
        }
        private async void DeleteItem()
        {
            if (await DisplayAlert("Delete Item?", "Are you sure you want to delete this item?", "Confirm", "Cancel"))
            {
                MessagingCenter.Send(this, "RemoveItem", Tile);
                await Navigation.PopAsync();
            }
        }
    }
}