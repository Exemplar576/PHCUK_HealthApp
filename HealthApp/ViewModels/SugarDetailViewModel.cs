using HealthApp.Models;

namespace HealthApp.ViewModels
{
    class SugarDetailViewModel : BaseViewModel
    {
        private Tiles _Tile;
        public Tiles Tile
        {
            get
            {
                return _Tile;
            }
            set
            {
                _Tile = value;
                SetPropertyValue(ref _Tile, value, "Tile");
            }
        }
    }
}
