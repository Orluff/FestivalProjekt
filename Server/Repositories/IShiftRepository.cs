using System;
namespace Server.Repositories
{
    public interface IShiftRepository
    {
        ShiftDTO[] getShifts();
        void AddShift(ShiftDTO shift);
        void RemoveShift(int id);
        void RemoveSpot(ShiftDTO shift);

        void AddSpot(ShiftDTO shift);
        void UpdateShift(ShiftDTO shift);
    }
}
