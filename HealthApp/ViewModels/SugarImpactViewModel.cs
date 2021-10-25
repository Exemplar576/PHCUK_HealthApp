using HealthApp.BetaTestData;
using HealthApp.Models;
using HealthApp.Views;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace HealthApp.ViewModels
{
    class SugarImpactViewModel : BaseViewModel
    {
        public ObservableCollection<Tiles> _RootTiles { get; private set; }
        private ObservableCollection<Tiles> _Tiles;
        public ObservableCollection<Tiles> Tiles
        {
            get
            {
                return _Tiles;
            }
            set
            {
                if (_Tiles != value)
                {
                    _Tiles = value;
                    SetPropertyValue(ref _Tiles, value, "Tiles");
                }
            }
        }
        public SugarImpactViewModel()
        {
            MessagingCenter.Subscribe<SugarDetail, Tiles>(this, "AddItem", (sender, args) => { _RootTiles.Add(args); }); 
            MessagingCenter.Subscribe<SugarDetail, Tiles>(this, "RemoveItem", (sender, args) => { _RootTiles.Remove(args); Tiles.Remove(args); });
            Tiles = new ObservableCollection<Tiles>(Data.FoodData.OrderBy(i => i.Name).ToList());
            _RootTiles = _Tiles;
        }
    }
}
