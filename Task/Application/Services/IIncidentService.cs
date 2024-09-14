using Domain.Requests;

namespace Application.Services;

public interface IIncidentService
{
    Task CreateIncidentAsync(IncidentRequest incidentRequest);
}