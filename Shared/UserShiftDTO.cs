using System;
using System.ComponentModel.DataAnnotations;

//DTO = Data Transfer Object

public class UserShiftDTO
{
    public int userShift_id { get; set; }

    public int user_id { get; set; }

    public int shift_id { get; set; }
}

