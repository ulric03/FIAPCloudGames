using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPCloudGames.Domain.Interfaces;

public interface IUnitOfWork
{
    Task CommitAsync(bool commitTransaction = true);

    Task CommitAsync(CancellationToken cancellationToken, bool commitTransaction = true);

    Task RollbackAsync();
}
