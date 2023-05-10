using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
[BsonIgnoreExtraElements]


public class Shift
{
    public string objekt_id { get; set; }

    public Boolean priority { get; set; }

    public DateTime start { get; set; } = DateTime.Now.AddHours(+2);

    public DateTime end { get; set; } = DateTime.Now.AddHours(+2).AddDays(+3);

    public double duration { get; set; } = 0;

    public string person_id { get; set; } = "";

    public string area { get; set; } = "";

    public string description { get; set; } = "";
}

