using System;
namespace Core2.Interfaces
{
	public interface IKeyGenerator
	{
		string GetKey(string emailAddress);
	}
}

