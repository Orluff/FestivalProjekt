using System;
using Client;
namespace Client.Services
{
	public interface IUserShiftService
	{
		//Hent alle brugerens vagter
		Task<IEnumerable<UserShiftDTO>> GetUserShifts();

		//Vælg vagt
		Task TakeShift(UserShiftDTO userShift, ShiftDTO shift);

		//Fjern brugerens vagt
        Task RemoveUserShift(ShiftDTO shift);
    }
}