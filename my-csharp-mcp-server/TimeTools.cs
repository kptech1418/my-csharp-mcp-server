using System;
using System.ComponentModel;
using ModelContextProtocol.Server;

namespace my_csharp_mcp_server;

[McpServerToolType]
public static class TimeTools
{
    [McpServerTool(Name = "TimeZone", Title = "Get Current Time"), Description("Returns the current time for the specified time zone.")]
    [McpMeta("openai/outputTemplate", "ui://widget/timezone.html")]
    [McpMeta("openai/widgetAccessible", true)]
    [McpMeta("openai/resultCanProduceWidget", true)]
    [McpMeta("openai/toolInvocation/invoking", "invoking...")]
    [McpMeta("openai/toolInvocation/invoked", "invoked...")]
    public static string GetCurrentTime(string timeZone)
    {
        try
        {
            var tz = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tz);
            return now.ToString("o"); // ISO 8601 format
        }
        catch (TimeZoneNotFoundException)
        {
            return $"Time zone '{timeZone}' not found.";
        }
        catch (InvalidTimeZoneException)
        {
            return $"Time zone '{timeZone}' is invalid.";
        }
    }
}
