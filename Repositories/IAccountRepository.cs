public interface IAccountRepository
{
    // 6) There should be an API endpoint for creating an account for an existing Customer
    void CreateAccount(Accounts account);

    // 8) There should be an API endpoint for deleting an account for the specific Customer
    void DeleteAccount(int accountId, Customer customer);

    // 9) There should be an API endpoint for fetching all the accounts of a specific Customer, based on the customer id field (All customer fields and account fields should be returned as a response)
    IEnumerable<CustomerAccounts> GetAllCustomerAccounts(int customerId);

    // 10) There should be an API endpoint for fetching all the accounts of all Customers
    IEnumerable<Accounts> GetAllAccounts();

    IEnumerable<Accounts> GetSpecificAccount(int accountId);
    
}