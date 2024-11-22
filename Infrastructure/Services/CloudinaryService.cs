using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Core.Models;
using Core.Services;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services
{
    public class CloudinaryService : IImageService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IOptions<CloudinarySettings> config)
        {
            var cloudinaryAccount = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(cloudinaryAccount);
        }

        public async Task<string> UploadImage(FileData file, string folderName, string fileName)
        {
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, new MemoryStream(file.Content)),
                PublicId = $"{folderName}/{fileName}",
                Overwrite = true
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return uploadResult.SecureUrl.ToString();
            }

            throw new Exception("Erro ao fazer upload da imagem para o Cloudinary");
        }
    }
}

