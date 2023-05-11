using System;
namespace Server.Repositories
{
    public interface IShiftRepository
    {
        Shift[] getShifts();
        void AddShift(Shift item);
        void TakeShift(Shift item);
        void ReleaseShift(int id);
    }
}
