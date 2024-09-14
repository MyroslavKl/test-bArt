

using Application.Requests;

namespace Application.Services;

public interface IIncidentService
{
    Task CreateIncidentAsync(IncidentRequest incidentRequest);
}