
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using AutoMapper;
using Microsoft.OpenApi.Extensions;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountRepository _accountRepo;
    private readonly ICustomerRepository _customerRepo;
    private readonly ApiDbContext _dbContext;
    private readonly IMapper _mapper;

    public AccountController(IAccountRepository accountRepo, ICustomerRepository customerRepo, 
                             ApiDbContext dbContext, IMapper mapper)
    {
        _accountRepo = accountRepo;
        _customerRepo = customerRepo;
        _dbContext = dbContext;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("CreateAccount")]
    public IActionResult CreateAccount(AccountRequestDto account, int customerId)
    {
        if (_customerRepo.SearchCustomerById(customerId).Count() == 0 || !ModelState.IsValid)
        {
            return BadRequest("Customer does not exist.");
        }

        if (!Enum.IsDefined(typeof(AccountTypes),account.AccountType))
        {
            return BadRequest("Account Type does not exist.");
        }

        var request = _mapper.Map<Accounts>(account);
        _accountRepo.CreateAccount(request);
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

        var response = _mapper.Map<IEnumerable<AccountResponseDTO>>(accounts);

        return Ok(response);
    }

    [HttpGet("{customerId}")]
    public IActionResult GetAllCustomerAccounts(int customerId)
    {
        if (_customerRepo.SearchCustomerById(customerId).Count() == 0)
        {
            return BadRequest("Customer does not exist.");
        }

        var customerAccounts = _accountRepo.GetAllCustomerAccounts(customerId);

        var request = _mapper.Map<IEnumerable<CustomerAccountResponseDto>>(customerAccounts);

        return Ok(request);
    }

}