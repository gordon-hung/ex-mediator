using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GH.ExMediator.Core.Models;

public record OrderInfo(
    string Id,
    string UserName,
    decimal Money,
    OrderStates State,
    DateTimeOffset CreatedTime,
    DateTimeOffset ConfirmedTime,
    DateTimeOffset CompletedTime,
    DateTimeOffset UpdateTime);
