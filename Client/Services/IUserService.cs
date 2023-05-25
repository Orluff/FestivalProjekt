using System;
using Client;
namespace Client.Services
{
	public interface IUserService
	{
		//Hent alle brugere
		Task<IEnumerable<UserDTO>> getUsers();

		//Hent alle brugere ud fra id
        Task<UserDTO> GetUserById(int userId);

		//Tilføj bruger
        Task AddUser(UserDTO item);

		//Opdater/rediger bruger
		Task UpdateUser(UserDTO item);

		//Fjern bruger
		Task RemoveUser(UserDTO item);
	}
}

