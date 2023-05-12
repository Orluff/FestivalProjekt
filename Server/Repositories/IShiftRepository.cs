using System;
namespace Server.Repositories
{
    public interface IShiftRepository
    {
        ShiftDTO[] getShifts();
        void AddShift(ShiftDTO item);
        void TakeShift(ShiftDTO item);
        void RemoveShift(int id);
    }
}
