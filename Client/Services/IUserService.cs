using System;
using Client;
namespace Client.Services
{
	public interface IUserService
	{
		Task<IEnumerable<UserDTO>> getUsers();
        Task<UserDTO> GetUserById(int userId);
        Task AddUser(UserDTO item);
		Task RemoveUser(UserDTO item);
	}
}

