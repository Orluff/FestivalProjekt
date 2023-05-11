using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
[BsonIgnoreExtraElements]


public class ShiftDTO
{
    public int shift_id { get; set; }

    public DateTime startDateTime { get; set; }

    public DateTime endDateTime { get; set; }

    public double duration { get; set; } = 0;

    public int category_id  { get; set; }

    public int? user_id { get; set; }

    public int status_id { get; set; }
}

