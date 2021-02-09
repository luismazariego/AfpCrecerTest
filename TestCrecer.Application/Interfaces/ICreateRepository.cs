namespace TestCrecer.Application.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Core;

    public interface ICreateRepository<T> where T : BaseEntity
    {
        void Add(T t);

        void Add(IEnumerable<T> t);

        Task AddAsync(T t);

        Task AddAsync(IEnumerable<T> t);
    }
}