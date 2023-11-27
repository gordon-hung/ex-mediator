using System;
using System.Runtime.CompilerServices;
using System.Threading;
using GH.ExMediator.Core;
using GH.ExMediator.Core.Extensions;
using GH.ExMediator.Core.Models;
using GH.ExMediator.Repositories.Models;
using Microsoft.Extensions.Caching.Memory;

namespace GH.ExMediator.Repositories;

internal class OrderRepository(IMemoryCache memoryCache) : IOrderRepository
{
    public async ValueTask AddAsync(long id, string userName, decimal money, CancellationToken cancellationToken = default)
    {
        var orders = await GetMemoryCacheAsync()
            .ToArrayAsync(cancellationToken: cancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<Order>();

        if (orders.FirstOrDefault(x => x.Id == id) is not null)
        {
            throw new InvalidOperationException($"The order already exists.({id})");
        }

        orders = orders.Append(new Order
        {
            Id = id,
            UserName = userName,
            Money = money,
            State = OrderStates.Processing.ToInt(),
            CreatedTime = DateTimeOffset.UtcNow,
            CompletedTime = DateTimeOffset.UnixEpoch,
            ConfirmedTime = DateTimeOffset.UnixEpoch,
            UpdateTime = DateTimeOffset.UtcNow
        });

        _ = memoryCache.Set(typeof(Order).GetTableName(), orders);
    }
    public async ValueTask<OrderInfo?> GetAsync(long id, CancellationToken cancellationToken = default)
    {
        var orders = await GetMemoryCacheAsync()
            .ToArrayAsync(cancellationToken: cancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<Order>();

        return orders.Where(predicate => predicate.Id == id).Select(selector => new OrderInfo(
            Id: selector.Id.ToString(),
            UserName: selector.UserName,
            Money: selector.Money,
            State: (OrderStates)selector.State,
            CreatedTime: selector.CreatedTime,
            ConfirmedTime: selector.ConfirmedTime,
            CompletedTime: selector.CompletedTime,
            UpdateTime: selector.UpdateTime)).FirstOrDefault();

    }
    public async IAsyncEnumerable<OrderInfo> QueryAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var orders = await GetMemoryCacheAsync()
            .ToArrayAsync(cancellationToken: cancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<Order>();

        if (!orders.Any())
        {
            yield break;
        }

        foreach (var order in orders)
        {
            yield return new OrderInfo(
            Id: order.Id.ToString(),
            UserName: order.UserName,
            Money: order.Money,
            State: (OrderStates)order.State,
            CreatedTime: order.CreatedTime,
            ConfirmedTime: order.ConfirmedTime,
            CompletedTime: order.CompletedTime,
            UpdateTime: order.UpdateTime);
        }
    }
    public async ValueTask UpdateConfirmedAsync(long id, CancellationToken cancellationToken = default)
    {
        var orders = await GetMemoryCacheAsync()
            .ToArrayAsync(cancellationToken: cancellationToken)
            .ConfigureAwait(false)
            ?? Enumerable.Empty<Order>();

        var order = orders.FirstOrDefault(x => x.Id == id) ?? throw new NullReferenceException($"The order does not exist.({id})");

        var update = new Order
        {
            Id = id,
            UserName = order.UserName,
            Money = order.Money,
            State = OrderStates.Confirmed.ToInt(),
            CreatedTime = order.CreatedTime,
            CompletedTime = DateTimeOffset.UtcNow,
            ConfirmedTime = DateTimeOffset.UnixEpoch,
            UpdateTime = DateTimeOffset.UtcNow
        };

        if (orders.ToList().Remove(order))
        {
            orders = orders.Append(update);
        }

        _ = memoryCache.Set(typeof(OrderInfo).GetTableName(), orders);
    }
    private IAsyncEnumerable<Order> GetMemoryCacheAsync()
    {
        _ = memoryCache.TryGetValue(typeof(Order).GetTableName(), out IEnumerable<Order>? orders);

        orders ??= Enumerable.Empty<Order>();

        return orders.ToAsyncEnumerable();
    }
}
