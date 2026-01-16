using System;
using System.ComponentModel;
using ModelContextProtocol.Server;

namespace my_csharp_mcp_server;

[McpServerResourceType]
public static class TimeResources
{
    [McpServerResource(IconSource = "", Name = "timezone-widget", Title = "timezone-widget", MimeType = "text/html+skybridge", UriTemplate = "ui://widget/timezone.html"), Description("Returns the timezone")]
    public static string GetTimezone() =>  "<html><body><b>my html</b></body></html>";
}
