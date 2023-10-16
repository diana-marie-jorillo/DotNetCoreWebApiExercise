public class CustomerAccountResponseDto
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string MiddleName { get; set; } 

    public string? FullName { get; set; }

    public DateTime DateOfBirth { get; set; }

    public bool IsFilipino { get; set; }

    public IEnumerable<AccountResponseDTO> AccountRecords { get; set; }

}