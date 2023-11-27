﻿using GH.ExMediator.Core;
using Microsoft.AspNetCore.Mvc;

namespace GH.ExMediator.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SnowflakeController : ControllerBase
{
    [HttpGet("DatacenterId")]
    public long GetDatacenterId(
        [FromServices] ISnowflakeWork work)
        => work.GetDatacenterId();

    [HttpGet("Id")]
    public long GetId(
        [FromServices] ISnowflakeWork work)
        => work.GetId();

    [HttpGet("IPAddress")]
    public string GetIPAddress(
        [FromServices] ISnowflakeWork work)
        => work.GetIPAddress().ToString();

    [HttpGet("WorkerId")]
    public long GetWorkerId(
        [FromServices] ISnowflakeWork work)
        => work.GetWorkerId();
}
