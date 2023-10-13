using System.ComponentModel.DataAnnotations;

public class CustomerRequestDTO
{
    [Required]
    [MaxLength(20)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string LastName { get; set; } = string.Empty;

    [MaxLength(20)]
    public string? MiddleName { get; set; }

    [Required]
    [CustomDateValidation]
    public DateTime DateOfBirth { get; set; }
    
    public bool IsFilipino { get; set; }

}