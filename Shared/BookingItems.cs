using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
[BsonIgnoreExtraElements]


public class BookingItems
{
    ShelterItems shelter = new ShelterItems();

    public string objekt_id { get; set; }

    public int BookingId { get; set; }

    public string fornavn { get; set; } = "";

    public string efternavn { get; set; } = "";

    public int tlf { get; set; } = 0;

    public string adresse { get; set; } = "";

    public string email { get; set; } = "";

    public DateTime start { get; set; } = DateTime.Now.AddHours(+2);

    public DateTime slut { get; set; } = DateTime.Now.AddHours(+2).AddDays(+3);

    public int antal_pers { get; set; } = 0;

    public string kommentar { get; set; } = "";
}

public class ShelterItems
{
    public Object _id { get; set; } = "";

    public string objekt_id { get; set; } = "";

    public double længdegrad { get; set; }

    public double breddegrad { get; set; } = 0.0;

    public DateTime oprettet { get; set; }

    public string cvr_navn { get; set; } = "";

    public string navn { get; set; } = "";

    public string beskrivels { get; set; } = "";

    public int antal_pl { get; set; } = 0;

    //Implementeres muligvis senere
    public int kommunekode { get; set; } = 0;

    public string status { get; set; } = null;

    public bool tilgængelighed { get; set; } = true;
}

