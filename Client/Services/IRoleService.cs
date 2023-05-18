using System;
using Client;
namespace Client.Services
{
	public interface IRoleService
	{
        Task<IEnumerable<RoleDTO>> getRole();
        //Task AddRole(RoleDTO role);
    }
}


