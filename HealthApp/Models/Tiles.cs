using Xamarin.Forms;

namespace HealthApp.Models
{
    public class Tiles
    {
        public string Name { get; set; }
        public ImageSource Image { get; set; }
        public string Type { get; set; }
        public float SpoonCount { get; set; }
        public int GlycaemicIndex { get; set; }
        public int ServeSize { get; set; }
        public string ItemType { get; set; }
    }
}
