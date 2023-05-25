using System;
using Client;
namespace Client.Services
{
	public interface IShiftService
	{
		//Hent alle vagter 
		Task<IEnumerable<ShiftDTO>> getShifts();

		//Tilføj vagt
        Task AddShift(ShiftDTO shift);

		//Fjern vagt
		Task RemoveShift(ShiftDTO shift);

		//Fjern en plads
		Task RemoveSpot(ShiftDTO shift);

		//Tilføj en plads
		Task AddSpot(ShiftDTO shift);

		//Rediger/Opdater vagt
        Task UpdateShift(ShiftDTO shift);
    }
}
