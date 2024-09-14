using Application.Requests;

namespace Application.Services;

public interface IAccountService
{
    Task CreateAccountAsync(AccountRequest accountRequest);
}