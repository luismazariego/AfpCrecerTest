namespace TestCrecer.Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Interfaces;
    using Interfaces.UnitOfWork;

    public abstract class BaseService<T> : IBaseService<T> where T : class
    {
        protected readonly IUnitOfWork _unitOfWork;

        protected BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public abstract Task<int> Create(T model);

        public abstract Task<int> Create(IEnumerable<T> list);

        public abstract Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate = null);

        public abstract Task Remove(T model);

        public abstract Task Remove(IEnumerable<T> list);

        public abstract Task<T> Single(Expression<Func<T, bool>> predicate = null);

        public abstract Task<int> Update(IEnumerable<T> list);

        public abstract Task<int> Update(T model);
    }
}