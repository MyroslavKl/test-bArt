using Application.Contracts;
using Application.Services;
using Domain;
using Domain.Exceptions;
using Domain.Requests;

namespace Infrastructure.Services;

public class IncidentService:IIncidentService
{
    private readonly IContactRepository _contactRepository;
    private readonly IIncidentRepository _incidentRepository;
    private readonly IAccountRepository _accountRepository;

    public IncidentService(IContactRepository contactRepository,
        IIncidentRepository incidentRepository,
        IAccountRepository accountRepository)
    {
        _incidentRepository = incidentRepository;
        _contactRepository = contactRepository;
        _accountRepository = accountRepository;
    }
    
    public async Task CreateIncidentAsync(IncidentRequest incidentRequest)
    {
        var account = await _accountRepository.GetByAsync(obj=>obj.Name == incidentRequest.AccountName);

        if (account == null)
        {
            throw new NotFoundException("Account Not Found");
        }

        var contact = await _contactRepository.GetByAsync(obj => obj.Email == incidentRequest.ContactEmail);
        
        if (contact != null)
        {
            contact.FirstName = incidentRequest.ContactFirstName;
            contact.LastName = incidentRequest.ContactLastName;
            
            if (contact.AccountId != account.Id)
            {
                contact.AccountId = account.Id;
                _contactRepository.Update(contact);
                await _contactRepository.SaveChangesAsync();
            }
        }
        else
        {
            contact = new Contact
            {
                FirstName = incidentRequest.ContactFirstName,
                LastName = incidentRequest.ContactLastName,
                Email = incidentRequest.ContactEmail,
                AccountId = account.Id
            };
            await _contactRepository.AddAsync(contact);
            await _contactRepository.SaveChangesAsync();
        }
        
        var incident = new Incident()
        {
            Description = incidentRequest.IncidentDescription,
            Accounts = new List<Account>
            {
                account
            }
        };

        await _incidentRepository.AddAsync(incident);
        await _incidentRepository.SaveChangesAsync();
    }
}