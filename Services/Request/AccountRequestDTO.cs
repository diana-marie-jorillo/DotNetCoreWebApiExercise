using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Storage;

public class AccountRequestDto
{
    [ForeignKey("CustomerId")]
    public int CustomerId { get; set; }

    [Required]
    [Range(1,999999999999, ErrorMessage ="Account Number must be 12 digits only.")]
    public double AccountNumber { get; set; }

    public AccountTypes AccountType { get; set; } 

    [Required] 
    [MaxLength(50,ErrorMessage ="Branch address should not be more than 50 characters.")]
    public string BranchAddress { get; set; } = string.Empty;

    [Required]
    [Range(0,1000000,ErrorMessage ="Initial Deposit should not exceed Php 1,000,000")]
    public decimal InitialDeposit { get; set; } = 0;

}