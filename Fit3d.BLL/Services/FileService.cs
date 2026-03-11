using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Configuration;

namespace Fit3d.BLL.Services
{
    public interface IFileService
    {
        Task<string?> SaveFileAsync(IFormFile? file, string folderName);
        FileStream? GetFileStream(string filePath);
    }

    public class FileService : IFileService
    {
        private readonly Cloudinary _cloudinary;

        public FileService(IConfiguration config)
        {
            var account = new Account(
                config["Cloudinary:CloudName"],
                config["Cloudinary:ApiKey"],
                config["Cloudinary:ApiSecret"]
            );
            _cloudinary = new Cloudinary(account);
        }

        public async Task<string?> SaveFileAsync(IFormFile? file, string folderName)
        {
            if (file == null || file.Length == 0) return null;

            using var stream = file.OpenReadStream();
            var publicId = Guid.NewGuid().ToString() + "_" + Path.GetFileNameWithoutExtension(file.FileName);
            var isImage = file.ContentType.StartsWith("image/");

            UploadResult uploadResult;

            if (isImage)
            {
                var imageParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Folder = $"fit3d/{folderName}",
                    PublicId = publicId
                };
                uploadResult = await _cloudinary.UploadAsync(imageParams);
            }
            else
            {
                var rawParams = new RawUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Folder = $"fit3d/{folderName}",
                    PublicId = publicId
                };
                uploadResult = await _cloudinary.UploadAsync(rawParams);
            }

            return uploadResult?.SecureUrl?.ToString();
        }

        public FileStream? GetFileStream(string filePath)
        {
            return null;
        }
    }
}