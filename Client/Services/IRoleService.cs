using System;
using Client;
namespace Client.Services
{
	public interface IRoleService
	{
        //Hent roller
        Task<IEnumerable<RoleDTO>> getRole();
    }
}


