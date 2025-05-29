using FIAPCloudGames.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace FIAPCloudGames.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly FCGContext _dbContext;
    private readonly IDbContextTransaction _dbContextTransaction;
    private readonly IServiceProvider _serviceProvider;

    public UnitOfWork(FCGContext dbContext, IServiceProvider serviceProvider)
    {
        _dbContext = dbContext;
        _serviceProvider = serviceProvider;

        if (_dbContext.Database.CurrentTransaction is null)
        {
            _dbContextTransaction = dbContext.Database.BeginTransaction();
        }
        else
        {
            _dbContextTransaction = dbContext.Database.CurrentTransaction;
        }
    }

    public async Task CommitAsync(bool commitTransaction = true)
    {
        _dbContext.SaveChanges();
        if (commitTransaction)
            await _dbContextTransaction.CommitAsync();
    }

    public async Task CommitAsync(CancellationToken cancellationToken, bool commitTransaction = true)
    {
        _dbContext.SaveChanges();
        if (commitTransaction)
            await _dbContextTransaction.CommitAsync(cancellationToken);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        _dbContext.Database.CurrentTransaction?.GetDbTransaction().Dispose();
        _dbContextTransaction?.Dispose();
        _dbContext.Database.GetDbConnection()?.Dispose();
    }

    public async Task RollbackAsync()
    {
        await _dbContextTransaction?.RollbackAsync();
    }
}
