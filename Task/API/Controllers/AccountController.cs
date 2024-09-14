using Application.Requests;
using Application.Services;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAccount([FromBody] AccountRequest accountRequest)
    {
        try
        {
            await _accountService.CreateAccountAsync(accountRequest);
            return Ok("Account created successfully.");
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}

}
