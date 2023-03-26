using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Pri.Ca.Core.Interfaces.Services;
using Pri.Ca.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Ca.Core.Services
{
    //dependencies

    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ImageResultModel> StoreImageAsync<T>(IFormFile image)
        {
            //create unique filename
            var fileName = $"{Guid.NewGuid()}_{image.FileName}";
            //generate correct directory
            var directory = Path.Combine(
                _webHostEnvironment.WebRootPath, "images",
                typeof(T).Name);
            //check if exists
            if(!Directory.Exists(directory))
            {
                //create directory
                Directory.CreateDirectory(directory);
            }
            //complete path to file
            var pathToFile = Path.Combine(directory, fileName);
            //copy the file
            using (FileStream fileStream = new(pathToFile,FileMode.CreateNew))
            {
                await image.CopyToAsync(fileStream);
            }
            //return filename to store in database
            return new ImageResultModel
            {
                IsSuccess = true,
                Image = fileName,
            };
        }
        public ImageResultModel DeleteImage<T>(string fileName)
        {
            throw new NotImplementedException();
        }

        public ImageResultModel GetImagePath<T>(string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<ImageResultModel> UpdateImageAsync<T>(IFormFile image, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
