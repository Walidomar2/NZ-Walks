using NZWalks.Models;

namespace NZWalks.Interfaces
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
