using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using TestCrecer.Application.Interfaces.UnitOfWork;
using TestCrecer.Infrastructure.Data;

namespace TestCrecer.Infrastructure.Repositories.UnitOfWork
{
    public class UnitOfWorkContainer : IUnitOfWork
    {
        private readonly TestCrecerContext _context;

        public UnitOfWorkContainer(TestCrecerContext context)
        {
            _context = context;
            Repository = new UnitOfWorkRepository(context);
        }

        public IUnitOfWorkRepository Repository { get; }

        #region Detect Changes

        public void DetectChanges()
        {
            _context.ChangeTracker.DetectChanges();
        }

        #endregion

        #region Save Changes

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        #endregion

        #region Transactions

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync().ConfigureAwait(false);
        }

        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            _context.Database.RollbackTransaction();
        }

        #endregion
    }
}