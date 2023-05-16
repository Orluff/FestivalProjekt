using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
[BsonIgnoreExtraElements]


public class ShiftDTO
{
    public int shift_id { get; set; }

    public DateTime startDateTime { get; set; } = DateTime.Now;

    public DateTime endDateTime { get; set; } = DateTime.Now;

    public double duration { get; set; } = 0;

    public int category_id  { get; set; }

    public bool priority { get; set; }

    public int spots { get; set; }

    //Bruges til at joine vores ShiftDTO med vores ShiftCategoryDTO
    public ShiftCategoryDTO category { get; set; }
}

