using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using api.Interfaces;

namespace api.Services
{
    public class FileService(IWebHostEnvironment environment) : IFileService
    {
  

        public async Task<string> SaveFileAsync(IFormFile imageFile, string[] allowedFileExtensions)
        {
            if (imageFile == null) {
                
                throw new ArgumentNullException(nameof(imageFile));
            }

            var contentPath = environment.ContentRootPath;
            var path = Path.Combine(contentPath, "Uploads");

            if(!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }

            var ext = Path.GetExtension(imageFile.FileName);

            if (!allowedFileExtensions.Contains(ext)) {

                throw new ArgumentException($"Only {string.Join(",", allowedFileExtensions)} are allowed.");
            }

            var fileName = $"{Guid.NewGuid().ToString()}{ext}";
            var fileNameWithPath = Path.Combine(path, fileName);

            using var stream = new FileStream(fileNameWithPath, FileMode.Create);

            await imageFile.CopyToAsync(stream);

            return fileName;
        
        }

        public void DeleteFile(string fileNameWithExtension) {

            if (string.IsNullOrEmpty(fileNameWithExtension)) {

                throw new ArgumentNullException(nameof(fileNameWithExtension));
            }

            var contentPath = environment.ContentRootPath;
            var path = Path.Combine(contentPath, $"Uploads", fileNameWithExtension);

            if (!File.Exists(path)) {

                throw new FileNotFoundException($"Invalid file path.");
            }

            File.Delete(path);
        }

        public async Task<byte[]> ConvertFromFileToByteArrAsync(IFormFile imageFile)
        {

            if (imageFile == null) {
                
                throw new ArgumentNullException(nameof(imageFile));
            }            

//        	imageFile.InputStream.Read(fileByte, 0, imageFile.Length);
            var memoryStream = new MemoryStream();

            await imageFile.CopyToAsync(memoryStream);


            byte[] fileByte = new byte[memoryStream.Length];

            fileByte = memoryStream.ToArray();


            memoryStream.Close();
            memoryStream.Dispose();

            return fileByte;
        }


    }
}