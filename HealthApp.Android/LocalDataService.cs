using Android.Content.Res;
using HealthApp.Droid;
using HealthApp.Services;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalDataService))]
namespace HealthApp.Droid
{
    class LocalDataService : ILocalDataService
    {
        private readonly string Base = "file:///android_asset/";
        public string Path()
        {
            return Base;
        }
        public string Data()
        {
            AssetManager assets = MainActivity.assetAccess;
            StreamReader reader = new StreamReader(assets.Open("local.html"));
            string data = reader.ReadToEnd();
            reader.Close();
            return data;
        }
    }
}