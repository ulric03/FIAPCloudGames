using FIAPCloudGames.Domain.Services;

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

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
