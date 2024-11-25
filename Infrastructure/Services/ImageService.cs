using System.Net.Http;
using Core.Models;
using Core.Services;

namespace Infrastructure.Services
{
    public class ImageService : IImageService
    {
        public async Task<string> UploadImage(FileData file, string folderName, string fileName)
        {
            string productsUploadFolderPath = Path.Combine("wwwroot", folderName);
            Directory.CreateDirectory(productsUploadFolderPath);

            string fullFileName = $"{fileName}{file.Extension}";
            string filePath = Path.Combine(productsUploadFolderPath, fullFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await stream.WriteAsync(file.Content, 0, file.Content.Length);
            }

            string fileUrl = $"/{folderName}/{fullFileName}";

            return fileUrl;
        }
    }
}