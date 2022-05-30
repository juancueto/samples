using System;
using Core2.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace Core2.Services
{
	public class LocalFileStorage : IFileStorage
	{
        private readonly IHostingEnvironment _env;

        public LocalFileStorage(IHostingEnvironment env)
        {
            _env = env;
        }

        public async Task StoreFile(IFormFile file, string key)
        {
            const string rootPath = "PhotoStore";
            var folder = $"{_env.WebRootPath}//{rootPath}//{key}";
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

            var fullFilePath = $"{folder}//{Path.GetFileName(file.FileName)}";

            using (var targetStream = new FileStream(fullFilePath, FileMode.Create))
            {
                await file.CopyToAsync(targetStream);
                targetStream.Close();
            }
        }
    }
}

