using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
[BsonIgnoreExtraElements]


public class Person
{
    public string objekt_id { get; set; }

    public string name { get; set; } = "";

    public string lastname { get; set; } = "";

    public int phoneNr { get; set; } = 0;

    public string address { get; set; } = "";

    public string email { get; set; } = "";

    public DateTime birthdate { get; set; } = DateTime.Now.AddHours(+2);

    public string role { get; set; } = "";
}