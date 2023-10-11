using System.Diagnostics;


// Used to return responses from the API.
// For generation, use Customer model.
public class CustomerDto
{
    public string LastName { get; set; } =  string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string? MiddleName { get; set; }

    public string? FullName { get; set; }

    public DateTime DateOfBirth { get; set; }

    public bool IsFilipino { get; set; }

}