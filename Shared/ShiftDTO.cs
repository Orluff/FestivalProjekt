using System;
using System.ComponentModel.DataAnnotations;

public class ShiftDTO
{
    public int shift_id { get; set; }

    public DateTime startDateTime { get; set; } = DateTime.Now;

    public DateTime endDateTime { get; set; } = DateTime.Now;

    public double duration { get; set; } = 0;

    public int category_id  { get; set; }

    public bool priority { get; set; }

    public int spots { get; set; }
}

