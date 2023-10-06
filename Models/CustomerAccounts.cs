public class CustomerAccounts
{

    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string MiddleName { get; set; } 

     public string? FullName { get; set; }

    public DateTime DateOfBirth { get; set; }

    public bool IsFilipino { get; set; }

    public IEnumerable<Accounts> AccountRecords { get; set; }
}