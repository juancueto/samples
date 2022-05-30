using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core2.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PersonalPhotos2.Filters;
using PersonalPhotos2.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalPhotos2.Controllers
{
    public class PhotosController : Controller
    {
        private readonly IFileStorage _fileStorage;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IKeyGenerator _keyGenerator;
        private readonly IPhotoMetaData _photoMetaData;

        public PhotosController(IKeyGenerator keyGenerator, IHttpContextAccessor httpContextAccessor,
            IPhotoMetaData photoMetaData, IFileStorage fileStorage)
        {
            _keyGenerator = keyGenerator;
            _httpContextAccessor = httpContextAccessor;
            _photoMetaData = photoMetaData;
            _fileStorage = fileStorage;
        }

        [ServiceFilter(typeof(LoginAttribute))]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        [ServiceFilter(typeof(LoginAttribute))]
        public async Task<IActionResult> Upload(PhotoUploadViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userName = _httpContextAccessor.HttpContext.Session.GetString("User");
                var uniqueKey = _keyGenerator.GetKey(userName);

                var fileName = Path.GetFileName(model.File.FileName);
                await _photoMetaData.SavePhotoMetaData(userName, model.Description, fileName);
                await _fileStorage.StoreFile(model.File, uniqueKey);
            }
            return RedirectToAction("Display");
        }

        [ServiceFilter(typeof(LoginAttribute))]
        public IActionResult Display()
        {
            var userName = _httpContextAccessor.HttpContext.Session.GetString("User");
            return View("Display", userName);
        }
    }
}

