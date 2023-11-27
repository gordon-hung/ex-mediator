using GH.ExMediator.Core.Models;
using MediatR;

namespace GH.ExMediator.Core.ApplicationServices;

internal class OrderGetHandler(IOrderRepository repository) : IRequestHandler<OrderGetRequest, OrderInfo?>
{
    public Task<OrderInfo?> Handle(OrderGetRequest request, CancellationToken cancellationToken)
        => repository.GetAsync(
            id: Convert.ToInt64(request.Id),
            cancellationToken: cancellationToken).AsTask();
}
