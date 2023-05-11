using System;
using Client;
namespace Client.Services
{
	public interface IShiftService
	{
		Task<IEnumerable<Shift>> getShifts();
		Task TakeShift(Shift item);
		Task ReleaseShift(Shift item);
	}
}

