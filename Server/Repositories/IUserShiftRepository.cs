using System;
namespace Server.Repositories
{
    public interface IUserShiftRepository
    {
        //Hent brugerens vagter
        UserShiftDTO[] GetUserShifts();

        //Vælg vagt
        void TakeShift(UserShiftDTO userShift);

        //Fjern brugerens vagt
        void RemoveShift(int id);
    }
}
