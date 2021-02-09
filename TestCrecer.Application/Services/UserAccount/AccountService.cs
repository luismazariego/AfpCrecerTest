namespace TestCrecer.Application.Services.UserAccount
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Core.Entities;

    using Interfaces.UnitOfWork;
    using Interfaces.UserAccount;

    public class AccountService : BaseService<Account>, IAccountService
    {
        public AccountService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override Task<int> Create(Account model)
        {
            _unitOfWork.Repository.AccountRepository.AddAsync(model);

            return _unitOfWork.SaveChangesAsync();
        }

        public override Task<int> Create(IEnumerable<Account> list)
        {
            _unitOfWork.Repository.AccountRepository.AddAsync(list);

            return _unitOfWork.SaveChangesAsync();
        }

        public override Task<IEnumerable<Account>> GetAll(Expression<Func<Account, bool>> predicate = null)
            => _unitOfWork.Repository.AccountRepository.GetAllNoTrackingAsync(predicate);


        public override Task Remove(Account model)
        {
            _unitOfWork.Repository.AccountRepository.Remove(model);

            return _unitOfWork.SaveChangesAsync();
        }

        public override Task Remove(IEnumerable<Account> list)
        {
            _unitOfWork.Repository.AccountRepository.Remove(list);

            return _unitOfWork.SaveChangesAsync();
        }

        public override Task<Account> Single(Expression<Func<Account, bool>> predicate = null)
            => _unitOfWork.Repository.AccountRepository.SingleOrDefaultAsync(predicate);

        public override Task<int> Update(IEnumerable<Account> list)
        {
            _unitOfWork.Repository.AccountRepository.Update(list);

            return _unitOfWork.SaveChangesAsync();
        }

        public override Task<int> Update(Account model)
        {
            _unitOfWork.Repository.AccountRepository.Update(model);

            return _unitOfWork.SaveChangesAsync();
        }
    }

}