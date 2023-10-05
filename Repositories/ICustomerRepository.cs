public interface ICustomerRepository
{

    // 1) There should be an API endpoint for creating a new Customer (POST Customer)
    void CreateCustomer(Customer customer);

    // 2) There should be an API endpoint for updating an existing Customer based on the CustomerId parameter (if the Customer doesn't exist, return an error with HTTP Status Code 400)
    //void UpdateCustomer(Customer customer);

    // 3) There should be an API endpoint for deleting an existing Customer based on the CustomerId parameter (if the Customer doesn't exist, return an error with HTTP Status Code 400)
    void DeleteCustomer(int customerId);

    // 4) There should be an API endpoint for fetching all the Customers
    IEnumerable<Customer> GetCustomers();

    // 5) There should be an API endpoint for fetching a specific Customer (based on the CustomerId parameter); if the Customer doesn't exist, please return an HTTP Status Code 400 with an error of "The customer does not exist."
    IEnumerable<Customer> SearchCustomerById(int customerId);

}