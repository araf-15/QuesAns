using Membership.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using System.IO;

namespace QuesAns.Models
{
    public class BaseModel
    {
        private readonly UserManager<ApplicationUser> _userService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string IMAGE_PATH = "temp";

        public BaseModel() 
        {
            _webHostEnvironment = Startup.AutofacContainer.Resolve<IWebHostEnvironment>();
            _httpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
            _userService = Startup.AutofacContainer.Resolve<UserManager<ApplicationUser>>();
        }

        public virtual (string fileName, string filePath) StoreFile(IFormFile file) 
        {
            var randomName = Path.GetRandomFileName().Replace(".", string.Empty);
            var newFileName = $"{randomName}{Path.GetExtension(file.FileName)}";

            var rootPath = _webHostEnvironment.WebRootPath;
            //var temp = _pathService.TempFolder;

            var fullPath = Path.Combine(rootPath, IMAGE_PATH);

            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            var path = Path.Combine(fullPath, newFileName);

            if (!File.Exists(path)) 
            {
                using var profileImage = File.OpenWrite(path);
                using var uploadFile = file.OpenReadStream();
                uploadFile.CopyTo(profileImage);
            }
            return (newFileName, path);
        }

        public string FormateImageUrl(string imageName)
        {
            return $"/{IMAGE_PATH}/{imageName}";
        }
        public string NoImageAvailableUrl()
        {
            return $"/{IMAGE_PATH}/NoImageAvail.jpg";
            
        }
    }
}
