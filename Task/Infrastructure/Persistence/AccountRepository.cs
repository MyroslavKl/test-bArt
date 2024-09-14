using Application.Contracts;
using Domain;
using Infrastructure.Data;
using Infrastructure.Persistence.Common;

namespace Infrastructure.Persistence;

public class AccountRepository:Repository<Account>,IAccountRepository
{
    public AccountRepository(TaskDbContext context) : base(context)
    {
    }
}