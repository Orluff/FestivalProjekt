﻿using System;
namespace Server.Repositories
{
    public interface IShiftRepository
    {
        ShiftDTO[] getShifts();
        void AddShift(ShiftDTO shift);
        void RemoveShift(int id);
        //ShiftCategoryDTO[] getCategories();
    }
}
