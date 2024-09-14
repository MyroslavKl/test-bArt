using Application.Contracts;
using Application.Services;
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
    
    public Task CreateIncidentAsync(IncidentRequest _incidentRequest)
    {
        throw new NotImplementedException();
    }
}