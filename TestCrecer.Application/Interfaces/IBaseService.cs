namespace TestCrecer.Application.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IBaseService<T>
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate = null);

        Task<T> Single(Expression<Func<T, bool>> predicate = null);

        Task<int> Create(T model);

        Task<int> Create(IEnumerable<T> list);

        Task Remove(T model);

        Task Remove(IEnumerable<T> list);

        Task<int> Update(IEnumerable<T> list);

        Task<int> Update(T model);
    }
}