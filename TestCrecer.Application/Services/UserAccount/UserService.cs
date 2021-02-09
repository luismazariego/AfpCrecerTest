namespace TestCrecer.Application.Services.UserAccount
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    
    using Core.Entities;
    
    using Interfaces.UnitOfWork;
    using Interfaces.UserAccount;

    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {            
        }

        public override Task<int> Create(User model)
        {
            _unitOfWork.Repository.UserRepository.AddAsync(model);

            return _unitOfWork.SaveChangesAsync();
        }

        public override Task<int> Create(IEnumerable<User> list)
        {
            _unitOfWork.Repository.UserRepository.AddAsync(list);

            return _unitOfWork.SaveChangesAsync();
        }

        public override Task<IEnumerable<User>> GetAll(Expression<Func<User, bool>> predicate = null)
            => _unitOfWork.Repository.UserRepository.GetAllNoTrackingAsync(predicate);


        public override Task Remove(User model)
        {
            _unitOfWork.Repository.UserRepository.Remove(model);

            return _unitOfWork.SaveChangesAsync();
        }

        public override Task Remove(IEnumerable<User> list)
        {
            _unitOfWork.Repository.UserRepository.Remove(list);

            return _unitOfWork.SaveChangesAsync();
        }

        public override Task<User> Single(Expression<Func<User, bool>> predicate = null)
            => _unitOfWork.Repository.UserRepository.SingleOrDefaultAsync(predicate);

        public override Task<int> Update(IEnumerable<User> list)
        {
            _unitOfWork.Repository.UserRepository.Update(list);

            return _unitOfWork.SaveChangesAsync();
        }

        public override Task<int> Update(User model)
        {
            _unitOfWork.Repository.UserRepository.Update(model);

            return _unitOfWork.SaveChangesAsync();
        }
    }
}