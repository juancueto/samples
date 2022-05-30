using System;
using Microsoft.AspNetCore.Http;

namespace Core2.Interfaces
{
	public interface IFileStorage
	{
		Task StoreFile(IFormFile file, string key);
	}
}

