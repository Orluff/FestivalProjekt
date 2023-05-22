using System;
using Client;
namespace Client.Services
{
	public interface IShiftService
	{
		Task<IEnumerable<ShiftDTO>> getShifts();
        Task AddShift(ShiftDTO shift);
		Task RemoveShift(ShiftDTO shift);
		Task RemoveSpot(ShiftDTO shift);
        Task UpdateShift(ShiftDTO shift);
    }
}
