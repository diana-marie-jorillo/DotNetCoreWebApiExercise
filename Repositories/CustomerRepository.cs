using Microsoft.EntityFrameworkCore;

public class CustomerRepository : ICustomerRepository 
{
    private readonly ApiDbContext _dbContext;

    public CustomerRepository(ApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Customer> GetCustomers
    {
        get {
            return _dbContext.Customers.ToList();
        }
    }

    IEnumerable<Customer> ICustomerRepository.GetCustomers()
    {
        return _dbContext.Customers.ToList();
    }

    public IEnumerable<Customer> SearchCustomerById(int customerId)
    {
        return _dbContext.Customers.Where(c => c.Id == customerId);
    }

    public void CreateCustomer(Customer customer)
    {
        _dbContext.Customers.Add(customer);
        _dbContext.SaveChanges();
    }

    public void DeleteCustomer(int customerId)
    {
        Customer customer = _dbContext.Customers
                                      .Where(c => c.Id == customerId)
                                      .FirstOrDefault();

        _dbContext.Customers.Remove(customer);
        _dbContext.SaveChanges();
    }

    public void UpdateCustomerById(int customerId, Customer data)
    {
        var temp = _dbContext.Customers.Where(c => c.Id == customerId).FirstOrDefault();

        temp.DateOfBirth = data.DateOfBirth;
        temp.IsFilipino = data.IsFilipino;
        temp.FirstName = data.FirstName;
        temp.LastName = data.LastName;
        temp.MiddleName = data.MiddleName;
        
        
    }
}