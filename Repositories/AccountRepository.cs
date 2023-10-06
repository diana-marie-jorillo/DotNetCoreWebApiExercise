using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;

public class AccountRepository : IAccountRepository
{
    private readonly ApiDbContext _dbContext;

    public AccountRepository(ApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Accounts> GetAllAccounts()
    {
       return _dbContext.Accounts.ToList();
    }

    public IEnumerable<Accounts> GetSpecificAccount(int accountId)
    {
        return _dbContext.Accounts.Where(x => x.Id == accountId)
                                 .ToList();
    }

    public void DeleteAccount(int accountId, Customer data)
    {
        var temp = _dbContext.Accounts
                             .Where(x => x.CustomerId == data.Id && x.Id == accountId)
                             .FirstOrDefault();
        
        _dbContext.Accounts.Remove(temp);
        _dbContext.SaveChanges();
    }

    public void CreateAccount(Accounts account)
    {
        _dbContext.Accounts.Add(account);
        _dbContext.SaveChanges();
    }

    public IEnumerable<CustomerAccounts> GetAllCustomerAccounts(int customerId)
    {
        // Get specific customer data for consolidation later
        Customer customer = _dbContext.Customers
                                      .Where(c => c.Id == customerId)
                                      .FirstOrDefault();

        
        // Get all accounts under customer
        IEnumerable<Accounts> accounts = _dbContext.Accounts
                                                   .Where(a => a.CustomerId == customerId)
                                                   .ToList();

        // Combine results
        IEnumerable<CustomerAccounts> result = new List<CustomerAccounts> {
            new CustomerAccounts {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                MiddleName = customer.MiddleName,
                DateOfBirth = customer.DateOfBirth,
                IsFilipino = customer.IsFilipino,
                AccountRecords = accounts
            }
        };

        return result;
    }
}