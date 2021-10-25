using Android.Content;
using HealthApp.Droid;
using HealthApp.Services;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(ImageService))]
namespace HealthApp.Droid
{
    class ImageService : IImageService
    {
        public Task<Stream> GetImageAsync()
        {
            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);
            MainActivity.Instance.StartActivityForResult(Intent.CreateChooser(intent, "Select Picture"),MainActivity.PickImageId);
            MainActivity.Instance.PickImageTaskCompletionSource = new TaskCompletionSource<Stream>();
            return MainActivity.Instance.PickImageTaskCompletionSource.Task;
        }
    }
}