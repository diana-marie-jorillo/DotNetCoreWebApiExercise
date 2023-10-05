
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop.Infrastructure;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _customerRepo;

    public CustomerController(ICustomerRepository customerRepo)
    {
        _customerRepo = customerRepo;
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
            return BadRequest();
        }

        customers = _customerRepo.SearchCustomerById(customerId);
        return Ok(customers);
    }

    [HttpPost]
    public IActionResult CreateCustomer(Customer customer)
    {
        if (ModelState.IsValid)
        {
            _customerRepo.CreateCustomer(customer);
            return Ok();
        }

        return BadRequest();
    }

    [HttpDelete("{customerId}")]
    public IActionResult DeleteCustomer(int customerId)
    {
        IEnumerable<Customer> customers;

        if (_customerRepo.SearchCustomerById(customerId).Count() == 0)
        {
            return BadRequest();
        }

        _customerRepo.DeleteCustomer(customerId);
        return Ok();
    }
}