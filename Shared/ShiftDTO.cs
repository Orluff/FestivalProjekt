using System;
using System.ComponentModel.DataAnnotations;

//DTO = Data Transfer Object

public class ShiftDTO
{
    public int shift_id { get; set; }

    public DateTime startDateTime { get; set; } = DateTime.Now;

    public DateTime endDateTime { get; set; } = DateTime.Now;

    public double duration { get; set; } = 0;

    public int category_id  { get; set; }

    public bool priority { get; set; }

    public int spots { get; set; }

    // Bruges til rettelser i vagter, efter de er lavet
    public bool IsEditing { get; set; }
}

