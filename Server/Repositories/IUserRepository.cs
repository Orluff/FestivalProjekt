using System;
namespace Server.Repositories
{
    public interface IUserRepository
    {
        //Hent brugere
        UserDTO[] getUsers();

        //Tilføj bruger
        void AddUser(UserDTO item);

        //Opdater/rediger brugerinfo
        void UpdateUser(UserDTO item);

        //Fjern bruger
        void RemoveUser(int id);
    }
}
