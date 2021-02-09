namespace TestCrecer.Application.Interfaces.UnitOfWork
{
    using UserAccount;
    
    public interface IUnitOfWorkRepository
    {
        IUserRepository UserRepository { get; }
        IAccountRepository AccountRepository { get; }
    }
}