using System;
using Client;
namespace Client.Services
{
	public interface IUserShiftService
	{
		Task<IEnumerable<UserShiftDTO>> GetUserShifts();
		Task TakeShift(UserShiftDTO userShift, ShiftDTO shift);
        Task RemoveUserShift(ShiftDTO shift);
    }
}