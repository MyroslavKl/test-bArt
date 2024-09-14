using Application.Contracts;
using Domain;
using Infrastructure.Data;
using Infrastructure.Persistence.Common;

namespace Infrastructure.Persistence;

public class IncidentRepository:Repository<Incident>,IIncidentRepository
{
    public IncidentRepository(TaskDbContext context) : base(context)
    {
    }
}