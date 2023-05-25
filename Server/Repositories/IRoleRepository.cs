using System;
namespace Server.Repositories
{
	public interface IRoleRepository
	{
        //Hent roller
        RoleDTO[] getRole();
    }
}

