using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace GH.ExMediator.Core.ApplicationServices;

internal class OrderAddHandler(ISnowflakeWork snowflake, IOrderRepository repository) : IRequestHandler<OrderAddRequest, long>
{
    public async Task<long> Handle(OrderAddRequest request, CancellationToken cancellationToken)
    {
        var id = snowflake.GetId();

        await repository.AddAsync(
            id: id,
            userName: request.UserName,
            money: request.Money,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        return id;
    }
}
