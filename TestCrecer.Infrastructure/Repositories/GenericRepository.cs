namespace TestCrecer.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Core;

    using Data;
    using Microsoft.EntityFrameworkCore;

    public class GenericRepository<T> where T : BaseEntity
    {
        protected TestCrecerContext _context;

        protected IQueryable<T> PrepareQuery(
           IQueryable<T> query,
           Expression<Func<T, bool>> predicate = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           int? take = null
       )
        {
            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = orderBy(query);

            if (take.HasValue)
                query = query.Take(Convert.ToInt32(take));

            return query;
        }

        public virtual IEnumerable<T> GetAll(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? take = null)
        {
            var query = _context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, orderBy, take);

            return query.ToList();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? take = null)
        {
            var query = _context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, orderBy, take);

            return await query.ToListAsync().ConfigureAwait(false);
        }

        public virtual IEnumerable<T> GetAllNoTracking(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? take = null)
        {
            var query = _context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, orderBy, take);

            return query.AsNoTracking().ToList();
        }

        public virtual async Task<IEnumerable<T>> GetAllNoTrackingAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? take = null)
        {
            var query = _context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, orderBy, take);

            return await query.AsNoTracking().ToListAsync().ConfigureAwait(false);
        }

        public virtual T First(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            var query = _context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, orderBy);

            return query.First();
        }

        public virtual async Task<T> FirstAsync(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            var query = _context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, orderBy);

            return await query.FirstAsync().ConfigureAwait(false);
        }

        public virtual T FirstOrDefault(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            var query = _context.Set<T>().AsQueryable().AsNoTracking();

            query = PrepareQuery(query, predicate, orderBy);

            return query.FirstOrDefault();
        }

        public virtual async Task<T> FirstOrDefaultAsync(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            var query = _context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, orderBy);

            return await query.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public virtual T Single(
            Expression<Func<T, bool>> predicate)
        {
            var query = _context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate);

            return query.Single();
        }

        public virtual async Task<T> SingleAsync(
            Expression<Func<T, bool>> predicate)
        {
            var query = _context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate);

            return await query.SingleAsync().ConfigureAwait(false);
        }

        public virtual T SingleOrDefault(
            Expression<Func<T, bool>> predicate)
        {
            var query = _context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate);

            return query.SingleOrDefault();
        }

        public virtual async Task<T> SingleOrDefaultAsync(
            Expression<Func<T, bool>> predicate)
        {
            var query = _context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate);

            return await query.SingleOrDefaultAsync().ConfigureAwait(false);
        }

        public virtual void Add(T t)
        {
            _context.Add(t);
        }

        public virtual void Add(IEnumerable<T> t)
        {
            _context.AddRange(t);
        }

        public virtual async Task AddAsync(T t)
        {
            await _context.AddAsync(t).ConfigureAwait(false);
        }

        public virtual async Task AddAsync(IEnumerable<T> t)
        {
            await _context.AddRangeAsync(t).ConfigureAwait(false);
        }

        public virtual void Remove(T t)
        {
            _context.Remove(t);
        }

        public virtual void Remove(IEnumerable<T> t)
        {
            _context.RemoveRange(t);
        }

        public virtual void Update(T t)
        {
            _context.Update(t);
        }

        public virtual void Update(IEnumerable<T> t)
        {
            _context.UpdateRange(t);
        }
    }
}