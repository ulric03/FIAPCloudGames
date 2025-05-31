using FIAPCloudGames.Domain.Interfaces;
using FIAPCloudGames.Infrastructure.Database;

namespace FIAPCloudGames.Infrastructure.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FCGContext _context;

        public UnitOfWork(FCGContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task CommitAsync(bool commitTransaction = true)
        {
            throw new NotImplementedException();
        }

        public async Task CommitAsync(CancellationToken cancellationToken, bool commitTransaction = true)
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task RollbackAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
