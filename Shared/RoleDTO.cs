using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
[BsonIgnoreExtraElements]


public class RoleDTO
{
    public int role_id { get; set; }

    public string roleName { get; set; }

    public string? description { get; set; }
}