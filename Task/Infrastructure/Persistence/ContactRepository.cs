using Application.Contracts;
using Domain;
using Infrastructure.Data;
using Infrastructure.Persistence.Common;

namespace Infrastructure.Persistence;

public class ContactRepository:Repository<Contact>, IContactRepository
{
    public ContactRepository(TaskDbContext context) : base(context)
    {
    }
}