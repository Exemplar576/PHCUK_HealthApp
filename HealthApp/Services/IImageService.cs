using System.IO;
using System.Threading.Tasks;

namespace HealthApp.Services
{
    public interface IImageService
    {
        Task<Stream> GetImageAsync();
    }
}
