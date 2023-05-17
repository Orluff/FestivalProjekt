using System;
namespace Server.Repositories
{
    public interface IUserShiftRepository
    {
        UserShiftDTO[] GetUserShifts();
        void TakeShift(UserShiftDTO userShift);
    }
}
