using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
[BsonIgnoreExtraElements]


public class ShiftPriority
{
    public int priority_id { get; set; }

    public bool priority { get; set; }
}

