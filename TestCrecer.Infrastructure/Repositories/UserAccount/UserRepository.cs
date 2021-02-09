using TestCrecer.Application.Interfaces.UserAccount;
using TestCrecer.Core.Entities;
using TestCrecer.Infrastructure.Data;

namespace TestCrecer.Infrastructure.Repositories.UserAccount
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(TestCrecerContext context)
        {
            _context = context;
        }
    }
}