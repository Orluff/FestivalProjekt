using System;
using System.ComponentModel.DataAnnotations;

public class UserDTO
{
    public int user_id { get; set; }

    //Validering af fornavn
    [StringLength(40, ErrorMessage = "Navnet er for langt")]
    [MinLength(1, ErrorMessage = "Udfyld fornavn")]
    public string name { get; set; }

    //Validering af efternavn
    [StringLength(40, ErrorMessage = "Navnet er for langt")]
    [MinLength(1, ErrorMessage = "Udfyld efternavn")]
    public string lastName { get; set; }

    public string address { get; set; }

    //Validering af email
    [EmailAddress(ErrorMessage = "Indtast en valid email")]
    public string email { get; set; }

    //Validering af minimums længde på telefon nummer
    [StringLength(8, MinimumLength = 8, ErrorMessage = "Telefon nummer skal indehold mindst 8-cifre")]
    public string telephone { get; set; }

    public DateTime birthDate { get; set; }

    public int role_id { get; set; }

    //Validering af password
    [MinLength(5, ErrorMessage = "Password skal være mindst 5 tegn")]
    public string password { get; set; }
}