using System;
namespace Server.Repositories
{
    public interface IUserRepository
    {
        UserDTO[] getUsers();
        void AddUser(UserDTO item);
        void UpdateUser(UserDTO item);
        void RemoveUser(int id);
    }
}
