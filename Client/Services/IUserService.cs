using System;
using Client;
namespace Client.Services
{
	public interface IUserService
	{
		Task<IEnumerable<UserDTO>> getUsers();
		Task AddUser(UserDTO item);
		Task RemoveUser(UserDTO item);
	}
}

