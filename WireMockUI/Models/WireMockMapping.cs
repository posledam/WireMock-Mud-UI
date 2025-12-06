namespace WireMockUI.Models;

public class WireMockMapping
{
    public Guid Guid { get; set; }
    public Request? Request { get; set; }
    public Response? Response { get; set; }
    public string? Title { get; set; }
    public int Priority { get; set; }
    public string? Scenario { get; set; }
}

public class Request
{
    public string? Path { get; set; }
    public string[]? Methods { get; set; }
    public Dictionary<string, object>? Headers { get; set; }
    public Dictionary<string, object>? QueryParams { get; set; }
    public object? Body { get; set; }
}

public class Response
{
    public int StatusCode { get; set; }
    public string? Body { get; set; }
    public Dictionary<string, string>? Headers { get; set; }
    public int Delay { get; set; }
}

public class MappingsList
{
    public WireMockMapping[]? Mappings { get; set; }
}
