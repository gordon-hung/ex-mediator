using GH.ExMediator.Core.Models;

namespace GH.ExMediator.Core;

public interface IOrderRepository
{
    public ValueTask AddAsync(long id, string userName, decimal money, CancellationToken cancellationToken = default);

    public IAsyncEnumerable<OrderInfo> QueryAsync(CancellationToken cancellationToken = default);

    public ValueTask<OrderInfo?> GetAsync(long id, CancellationToken cancellationToken = default);

    public ValueTask UpdateConfirmedAsync(long id, CancellationToken cancellationToken = default);
}
