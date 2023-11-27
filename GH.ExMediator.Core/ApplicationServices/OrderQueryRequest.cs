using GH.ExMediator.Core.Models;
using MediatR;

namespace GH.ExMediator.Core.ApplicationServices;

public record OrderQueryRequest : IStreamRequest<OrderInfo>
{
}
