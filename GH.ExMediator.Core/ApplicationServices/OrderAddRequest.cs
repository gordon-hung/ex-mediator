using MediatR;

namespace GH.ExMediator.Core.ApplicationServices;

public record OrderAddRequest : IRequest<long>
{
    public string UserName { get; init; } = default!;
    public decimal Money { get; init; }
}
