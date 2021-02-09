using TestCrecer.Application.Interfaces.UnitOfWork;
using TestCrecer.Application.Interfaces.UserAccount;
using TestCrecer.Infrastructure.Data;
using TestCrecer.Infrastructure.Repositories.UserAccount;

namespace TestCrecer.Infrastructure.Repositories.UnitOfWork
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public UnitOfWorkRepository(TestCrecerContext ctx)
        {
            UserRepository = new UserRepository(ctx);
            AccountRepository = new AccountRepository(ctx);
        }

        public IUserRepository UserRepository  { get; }

        public IAccountRepository AccountRepository { get; }
    }
}