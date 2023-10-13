
using AutoMapper;
using bdowebapi.Migrations;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _customerRepo;
    private readonly IMapper _mapper;

    public readonly ApiDbContext _dbContext;

    public CustomerController(ICustomerRepository customerRepo,
                              IMapper mapper, ApiDbContext dbContext)
    {
        _customerRepo = customerRepo;
        _mapper = mapper;
        _dbContext = dbContext;
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
        var response = _mapper.Map<IEnumerable<CustomerResponseDto>>(customers);

        foreach(var item in response)
        {
            item.FullName = string.IsNullOrEmpty(item.MiddleName) ? string.Concat(item.LastName, ", ", item.FirstName)
                                                                  : string.Concat(item.LastName, ", ", item.FirstName, " ", item.MiddleName.Substring(0,1), ".");
            item.DateOfBirth = item.DateOfBirth.Date;
        }
        

        return Ok(response);
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
        var response = _mapper.Map<IEnumerable<CustomerResponseDto>>(customers);

        foreach(var item in response)
        {
            item.FullName = string.IsNullOrEmpty(item.MiddleName) ? string.Concat(item.LastName, ", ", item.FirstName)
                                                                  : string.Concat(item.LastName, ", ", item.FirstName, " ", item.MiddleName.Substring(0,1), ".");
            item.DateOfBirth = item.DateOfBirth.Date;
        }

        return Ok(response);
    }

    [HttpPost]
    public IActionResult CreateCustomer(CustomerRequestDTO customer)
    {
        if (ModelState.IsValid)
        {
            var request = _mapper.Map<Customer>(customer);
            _customerRepo.CreateCustomer(request);
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

    /// <summary>
    /// Update one or more Customer details
    /// </summary>
    /// <param name="customerId">The Customer ID</param>
    /// <param name="patch">The change request</param>
    /// <returns></returns>
    [HttpPatch("{customerId}")]
    public IActionResult UpdateCustomerById(int customerId, 
                                           [FromBody] JsonPatchDocument<CustomerRequestDTO> patch)
    {
        // check if customer exists in database
        var customerToPatch = _customerRepo.SearchCustomerById(customerId).FirstOrDefault();

        if (customerToPatch == null || !ModelState.IsValid)
        {
            return BadRequest();
        }

        // Convert customerToPatch (Customer) to CustomerRequestDTO
        var dataToUpdate = _mapper.Map<CustomerRequestDTO>(customerToPatch);

        // Apply changes from JsonPatchDocument
        patch.ApplyTo(dataToUpdate);

        // Convert dataToUpdate(CustomerRequestDTO) back to Customer (customerToPatch) and apply changes.
        var updateRequest = _mapper.Map(dataToUpdate, customerToPatch);

        _dbContext.Update(updateRequest);
        _dbContext.SaveChanges();
   
        return Ok();
    }
}