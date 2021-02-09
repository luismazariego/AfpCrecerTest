namespace TestCrecer.Application.Interfaces.UserAccount
{
    using Core.Entities;

    public interface IAccountRepository : ICreateRepository<Account>,
        IReadRepository<Account>, IRemoveRepository<Account>,
        IUpdateRepository<Account>
    {        
    }
}