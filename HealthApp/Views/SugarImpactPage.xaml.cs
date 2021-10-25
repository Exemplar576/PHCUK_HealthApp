using HealthApp.Models;
using HealthApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HealthApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SugarImpactPage : ContentPage
    {
        private readonly SugarImpactViewModel model;
        public SugarImpactPage()
        {
            InitializeComponent();
            model = BindingContext as SugarImpactViewModel;
        }
        protected async void OnSearch(object sender, EventArgs e)
        {
            await MainView.FadeTo(0, 500);
            string search = ((SearchBar)sender).Text.ToLower();
            IEnumerable<Tiles> filteredItems = model._RootTiles;

            if (!string.IsNullOrEmpty(search))
            {
                filteredItems = model._RootTiles.Where(item => item.Name.ToLower().Contains(search));
            }
            model.Tiles = new ObservableCollection<Tiles>(filteredItems);
            await MainView.FadeTo(1, 500);
        }
        protected async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await MainView.FadeTo(0, 500);
            string type = ((Button)sender).Text;
            IEnumerable<Tiles> filteredItems = model._RootTiles;

            if (!type.Equals("All"))
            {
                filteredItems = model._RootTiles.Where(item => item.Type.Equals(type));
            }
            model.Tiles = new ObservableCollection<Tiles>(filteredItems);
            await MainView.FadeTo(1, 500);
        }
        protected async void OnItemTapped(object sender, EventArgs e)
        {
            string itemName = ((Frame)sender).ClassId;
            Tiles tile = model.Tiles.First(item => itemName.Equals(item.Name));

            await Navigation.PushAsync(new SugarDetail(tile));
        }
        protected async void OnInfoClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Info", 
                "These sugar infographics help people understand the approximate affect various" +
                " foods may have on their blood sugar in terms of a 4 gram teaspoon of sugar. For example, a" +
                " bowl of 150g of boiled rice is roughly equivalent to ten teaspoons of table sugar.",
                "Ok");
        }
        protected async void OnSortClicked(object sender, EventArgs e)
        {
            await MainView.FadeTo(0, 500);
            string name = ((ToolbarItem)sender).Text;
            IEnumerable<Tiles> ordered = model.Tiles;

            switch (name)
            {
                case "A-Z":
                    ordered = model.Tiles.OrderBy(i => i.Name);
                    break;
                case "Glycaemic Index":
                    ordered = model.Tiles.OrderByDescending(i => i.GlycaemicIndex);
                    break;
                case "Spoon Count":
                    ordered = model.Tiles.OrderByDescending(i => i.SpoonCount);
                    break;
                default:
                    break;
            }
            model.Tiles = new ObservableCollection<Tiles>(ordered);
            await MainView.FadeTo(1, 500);
        }
    }
}