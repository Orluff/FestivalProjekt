using System;
namespace Server.Repositories
{
    public interface IShiftRepository
    {
        //Hent vagter
        ShiftDTO[] getShifts();

        //Tilføj vagt
        void AddShift(ShiftDTO shift);

        //Fjern vagt
        void RemoveShift(int id);

        //Fjern plads
        void RemoveSpot(ShiftDTO shift);

        //Tilføj plads
        void AddSpot(ShiftDTO shift);

        //Opdater/rediger vagt
        void UpdateShift(ShiftDTO shift);
    }
}
