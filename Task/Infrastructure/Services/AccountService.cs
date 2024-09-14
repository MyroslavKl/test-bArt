using Application.Contracts;
using Application.Requests;
using Application.Services;
using Domain;
using Domain.Exceptions;

namespace Infrastructure.Services;

public class AccountService:IAccountService
{
    private readonly IContactRepository _contactRepository;
    private readonly IIncidentRepository _incidentRepository;
    private readonly IAccountRepository _accountRepository;

    public AccountService(IContactRepository contactRepository,
        IIncidentRepository incidentRepository,
        IAccountRepository accountRepository)
    {
        _incidentRepository = incidentRepository;
        _contactRepository = contactRepository;
        _accountRepository = accountRepository;
    }

    public async Task CreateAccountAsync(AccountRequest accountRequest)
    {
        var incident = await _incidentRepository.GetByAsync(obj => obj.IncidentName == accountRequest.IncidentName);
        if (incident == null)
        {
            throw new NotFoundException("Incident Not Found");
        }

        var contact = await _contactRepository.GetByAsync(obj => obj.Email == accountRequest.ContactEmail);

        if (contact == null)
        {
            contact = new Contact
            {
                FirstName = accountRequest.ContactFirstName,
                LastName = accountRequest.ContactLastName,
                Email = accountRequest.ContactEmail
            };
        }
        
        var account = new Account
        {
            Name = accountRequest.AccountName,
            IncidentName = accountRequest.IncidentName
        };
        
        contact.Account = account;
        await _accountRepository.AddAsync(account);
        await _accountRepository.SaveChangesAsync();
        
        await _contactRepository.AddAsync(contact);
        await _contactRepository.SaveChangesAsync();
    }
        

    
}