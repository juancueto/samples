using System;
using Core2.Interfaces;

namespace Core2.Services
{
	public class DefaultKeyGenerator: IKeyGenerator
	{
		public string GetKey(string emailAddress)
		{
			return emailAddress.Replace("@", string.Empty).Replace(".", string.Empty);
		}
	}
}

