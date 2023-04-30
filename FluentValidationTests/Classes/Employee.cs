using System.ComponentModel.DataAnnotations;

namespace FluentValidationTests.Classes;

public class Employee
{
    [Required]
    [MaxLength(50, ErrorMessage = "The maximum name length can only be 50 characters long")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Surname is Required. It cannot be empty")]
    public string Surname { get; set; } = "";
}