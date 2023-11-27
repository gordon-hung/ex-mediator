using GH.ExMediator.Core.Models;
using MediatR;

namespace GH.ExMediator.Core.ApplicationServices;

internal class OrderQueryHandle(IOrderRepository repository) : IStreamRequestHandler<OrderQueryRequest, OrderInfo>
{
    public IAsyncEnumerable<OrderInfo> Handle(OrderQueryRequest request, CancellationToken cancellationToken)
        => repository.QueryAsync(cancellationToken: cancellationToken);
}
