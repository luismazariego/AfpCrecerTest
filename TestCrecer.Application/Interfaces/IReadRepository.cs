namespace TestCrecer.Application.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Core;

    public interface IReadRepository <T> where T : BaseEntity
    {
        #region Get All

        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? take = null
            );

        Task<IEnumerable<T>> GetAllAsync(
           Expression<Func<T, bool>> predicate = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           int? take = null
           );

        IEnumerable<T> GetAllNoTracking(
           Expression<Func<T, bool>> predicate = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           int? take = null
           );

        Task<IEnumerable<T>> GetAllNoTrackingAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? take = null
            );

        #endregion

        #region Single

        T Single(Expression<Func<T, bool>> predicate = null);

        Task<T> SingleAsync(Expression<Func<T, bool>> predicate = null);

        T SingleOrDefault(Expression<Func<T, bool>> predicate = null);

        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate = null);

        #endregion

        #region First
        T First(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);

        Task<T> FirstAsync(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);

        T FirstOrDefault(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);

        Task<T> FirstOrDefaultAsync(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);

        #endregion
    }
}