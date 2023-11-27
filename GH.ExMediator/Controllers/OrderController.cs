using GH.ExMediator.Core;
using GH.ExMediator.Core.ApplicationServices;
using GH.ExMediator.Core.Models;
using GH.ExMediator.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GH.ExMediator.Controllers;

[Route("[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    /// <summary>
    /// Adds the asynchronous.
    /// </summary>
    /// <param name="mediator">The mediator.</param>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    [HttpPost]
    public async ValueTask<string> AddAsync(
        [FromServices] IMediator mediator,
        AddViewModel source)
    {
        var id = await mediator.Send(
            request: new OrderAddRequest
            {
                UserName = source.UserName,
                Money = source.Money
            },
            cancellationToken: HttpContext.RequestAborted)
            .ConfigureAwait(false);

        return id.ToString();
    }
    /// <summary>
    /// Queries the asynchronous.
    /// </summary>
    /// <param name="mediator">The mediator.</param>
    /// <returns></returns>
    [HttpGet]
    public IAsyncEnumerable<OrderInfo> QueryAsync(
        [FromServices] IMediator mediator)
        => mediator.CreateStream(
            new OrderQueryRequest(),
            HttpContext.RequestAborted);
    /// <summary>
    /// Gets the asynchronous.
    /// </summary>
    /// <param name="mediator">The mediator.</param>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async ValueTask<OrderInfo?> GetAsync(
    [FromServices] IMediator mediator,
    string id)
        => await mediator.Send(
        request: new OrderGetRequest
        {
            Id = id,
        },
        cancellationToken: HttpContext.RequestAborted)
        .ConfigureAwait(false);
}