using System;
using Core2.Models;

namespace Core2.Interfaces
{
	public interface IPhotoMetaData
	{
		Task SavePhotoMetaData(string userName, string desciption, string fileName);
		Task<List<PhotoModel>> GetUserPhotos(string userName);
	}
}

