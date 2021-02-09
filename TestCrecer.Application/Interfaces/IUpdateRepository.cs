namespace TestCrecer.Application.Interfaces
{
    using System.Collections.Generic;

    using Core;

    public interface IUpdateRepository<T> where T : BaseEntity
    {
        void Update(T t);

        void Update(IEnumerable<T> t);
    }
}