using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GH.ExMediator.Core.Models;
using MediatR;

namespace GH.ExMediator.Core.ApplicationServices;

public record OrderGetRequest : IRequest<OrderInfo?>
{
    public string Id { get; init; } = default!;
}
