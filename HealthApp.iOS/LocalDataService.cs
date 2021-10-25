using Foundation;
using HealthApp.iOS;
using HealthApp.Services;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalDataService))]
namespace HealthApp.iOS
{
    class LocalDataService : ILocalDataService
    {
        public string Path()
        {
            return NSBundle.MainBundle.BundlePath;
        }
        public string Data()
        {
            string path = NSBundle.MainBundle.PathForResource("local", "html");
            StreamReader reader = new StreamReader(path);
            string data = reader.ReadToEnd();
            reader.Close();
            return data;
        }
    }
}