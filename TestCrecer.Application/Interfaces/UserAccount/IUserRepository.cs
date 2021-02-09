namespace TestCrecer.Application.Interfaces.UserAccount
{
    using Core.Entities;
    public interface IUserRepository : ICreateRepository<User>,
        IReadRepository<User>, IRemoveRepository<User>,
        IUpdateRepository<User>
    {        
    }
}