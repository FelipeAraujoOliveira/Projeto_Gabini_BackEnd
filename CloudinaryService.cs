   using CloudinaryDotNet;
   using CloudinaryDotNet.Actions;
   using Microsoft.Extensions.Configuration;

   public class CloudinaryService : IImageService
   {
       private readonly Cloudinary _cloudinary;

       public CloudinaryService(IConfiguration configuration)
       {
           var cloudinarySettings = configuration.GetSection("CloudinarySettings").Get<CloudinarySettings>();
           _cloudinary = new Cloudinary(new Account(
               cloudinarySettings.CloudName,
               cloudinarySettings.ApiKey,
               cloudinarySettings.ApiSecret));
       }

       public async Task<string> UploadImage(FileData file, string folderName, string fileName)
       {
           using (var stream = new MemoryStream(file.Content))
           {
               var uploadParams = new ImageUploadParams()
               {
                   File = new FileDescription(fileName, stream),
                   Folder = folderName
               };

               var uploadResult = await _cloudinary.UploadAsync(uploadParams);
               return uploadResult.SecureUrl.ToString();
           }
       }
   }

   public class CloudinarySettings
   {
       public string CloudName { get; set; }
       public string ApiKey { get; set; }
       public string ApiSecret { get; set; }
   }
   