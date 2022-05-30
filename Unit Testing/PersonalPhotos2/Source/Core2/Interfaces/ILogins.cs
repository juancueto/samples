using System;
using Core2.Models;

namespace Core2.Interfaces
{
	public interface ILogins
	{
		Task CreateUser(string email, string password);
		Task<User> GetUser(string email);
	}
}

