namespace TestCrecer.Application.Interfaces
{
    using System.Collections.Generic;

    using Core;

    public interface IRemoveRepository<T> where T : BaseEntity
    {
        void Remove(T t);

        void Remove(IEnumerable<T> t);
    }
}