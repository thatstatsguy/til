using System.ComponentModel.DataAnnotations;

namespace FluentValidationTests.Classes;

public class Employee
{
    [Required(ErrorMessage = "Name is required. It cannot be empty")]
    [MaxLength(50, ErrorMessage = "The maximum name length can only be 50 characters long")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Surname is required. It cannot be empty")]
    [MaxLength(50, ErrorMessage = "The maximum surname length can only be 50 characters long")]
    public string? Surname { get; set; }
}