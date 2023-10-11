
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _customerRepo;
    private readonly IMapper _mapper;
    //private readonly IAccountRepository _accountRepo;

    //public CustomerController(ICustomerRepository customerRepo, IAccountRepository accountRepo)
    public CustomerController(ICustomerRepository customerRepo,
                              IMapper mapper)
    {
        _customerRepo = customerRepo;
        //_accountRepo = accountRepo;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetCustomers() 
    {
        IEnumerable<Customer> customers;

        if (_customerRepo.GetCustomers().Count() == 0)
        {
            return NotFound();
        }

        customers = _customerRepo.GetCustomers();
        return Ok(customers);
    }

    [HttpGet("{customerId}")]
    public IActionResult SearchCustomerById(int customerId)
    {
        IEnumerable<Customer> customers;

        if (_customerRepo.SearchCustomerById(customerId).Count() == 0)
        {
            return BadRequest("The customer does not exist.");
        }
        customers = _customerRepo.SearchCustomerById(customerId);
        return Ok(customers);
    }

    [HttpPost]
    public IActionResult CreateCustomer(Customer customer)
    {
        if (ModelState.IsValid)
        {
            if (string.IsNullOrEmpty(customer.MiddleName)){
                customer.FullName = string.Concat(customer.LastName, ", ", customer.FirstName);
            }
            else {
                customer.FullName = string.Concat(customer.LastName, ", ", customer.FirstName, " ", customer.MiddleName[..1], ".");
            }
        
            _customerRepo.CreateCustomer(customer);
            return Ok();
        }

        return BadRequest();
    }

    [HttpDelete("{customerId}")]
    public IActionResult DeleteCustomer(int customerId)
    {
        if (_customerRepo.SearchCustomerById(customerId).Count() == 0)
        {
            return BadRequest("The customer does not exist.");
        }

        // Commented for now since it's not part of the requirement.
        // This will prevent deletion if customer has existing accounts.
        // if (_accountRepo.GetAllCustomerAccounts(customerId).Count() > 0)
        // {
        //     return BadRequest("Delete failed. Customer has existing accounts.");
        // }

        _customerRepo.DeleteCustomer(customerId);
        return Ok();
    }

    [HttpPut]
    public IActionResult UpdateCustomerById(int customerId, Customer customer)
    {
        if (_customerRepo.SearchCustomerById(customerId).Count() == 0)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        if (string.IsNullOrEmpty(customer.MiddleName)){
            customer.FullName = string.Concat(customer.LastName, ", ", customer.FirstName);
        }
        else {
            customer.FullName = string.Concat(customer.LastName, ", ", customer.FirstName, " ", customer.MiddleName[..1], ".");
        }

        _customerRepo.UpdateCustomerById(customerId, customer);
        
        return Ok();
    }
}