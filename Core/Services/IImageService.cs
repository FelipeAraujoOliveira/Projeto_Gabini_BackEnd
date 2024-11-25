using Core.Models;

namespace Core.Services
{
    public interface IImageService
    {
        Task<string> UploadImage(FileData file, string folderName, string fileName);
    }
}