using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.SignalR;

public class Customer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(20)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string LastName { get; set; } = string.Empty;

    [MaxLength(20)]
    public string? MiddleName { get; set; }
    
    //public string? FullName { get; set; }

    [Required]
    [CustomDateValidation]
    public DateTime DateOfBirth { get; set; }

    public bool IsFilipino { get; set; } = false;

}

public class CustomDateValidation : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if ((DateTime)value > DateTime.Now){
            return new ValidationResult("Date of Birth must not be a future date.");
        }   

        return ValidationResult.Success;
    }
}