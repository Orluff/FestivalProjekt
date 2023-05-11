using System;
using Client;
namespace Client.Services
{
	public interface IShiftService
	{
		Task<IEnumerable<ShiftDTO>> getShifts();
		Task TakeShift(ShiftDTO item);
		Task ReleaseShift(ShiftDTO item);
	}
}

