using System.Net;

namespace GH.ExMediator.Core;

public interface ISnowflakeWork
{
    long GetDatacenterId();

    long GetId();

    IPAddress GetIPAddress();

    long GetWorkerId();
}
