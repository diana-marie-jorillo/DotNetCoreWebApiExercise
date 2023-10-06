
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountRepository _accountRepo;
    private readonly ICustomerRepository _customerRepo;
    private readonly ApiDbContext _dbContext;

    public AccountController(IAccountRepository accountRepo, ICustomerRepository customerRepo, 
                             ApiDbContext dbContext)
    {
        _accountRepo = accountRepo;
        _customerRepo = customerRepo;
        _dbContext = dbContext;
    }

    [HttpPost]
    [Route("CreateAccount")]
    public IActionResult CreateAccount(Accounts account)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest();
        }

        _accountRepo.CreateAccount(account);
        return Ok();
       
    }

    // 7) There should be an API endpoint for updating the account details 
    // based on the AccountId parameter, excluding the initialDeposit field
    [HttpPatch("{accountId}")]
    public IActionResult UpdateAccountDetails(int accountId, 
                        [FromBody] JsonPatchDocument<Accounts> patch)
    {
        var accountToPatch = _dbContext.Accounts
                                       .FirstOrDefault(x => x.Id == accountId);

        if(accountToPatch == null)
        {
            return BadRequest("Account does not exist");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        patch.ApplyTo(accountToPatch);
        _dbContext.Update(accountToPatch);
        _dbContext.SaveChanges();

        return Ok();
    }

    [HttpDelete("{accountId}")]
    public IActionResult DeleteAccount(int accountId, Customer customer)
    {
        if(_accountRepo.GetSpecificAccount(accountId).Count() == 0)
        {
            return BadRequest("Account does not exist");
        }

        _accountRepo.DeleteAccount(accountId, customer);
        return Ok();
    }

    [HttpGet]
    [Route("GetAllAccounts")]
    public IActionResult GetAllAccounts()
    {
        IEnumerable<Accounts> accounts;

        if(_accountRepo.GetAllAccounts().Count() == 0)
        {
            return NotFound("No accounts found.");
        }

        accounts = _accountRepo.GetAllAccounts();
        return Ok(accounts);
    }

    [HttpGet("{customerId}")]
    public IActionResult GetAllCustomerAccounts(int customerId)
    {
        if (_customerRepo.SearchCustomerById(customerId).Count() == 0)
        {
            return BadRequest("Customer does not exist.");
        }

        var request = _accountRepo.GetAllCustomerAccounts(customerId);
        return Ok(request);
    }

}