using System;
using System.ComponentModel.DataAnnotations;

//DTO = Data Transfer Object

public class RoleDTO
{
    public int role_id { get; set; }

    public string roleName { get; set; } = String.Empty;

    public string? description { get; set; }
}