using TestCrecer.Application.Interfaces.UserAccount;
using TestCrecer.Core.Entities;
using TestCrecer.Infrastructure.Data;

namespace TestCrecer.Infrastructure.Repositories.UserAccount
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(TestCrecerContext context)
        {
            _context = context;
        }
    }
}