namespace WireMockUI.Models;

public class CreateMappingRequest
{
    public string? Title { get; set; }
    public int Priority { get; set; } = 0;
    public RequestPattern Request { get; set; } = new();
    public ResponseDefinition Response { get; set; } = new();
}

public class RequestPattern
{
    public string? Path { get; set; }
    public string[]? Methods { get; set; }
    public Dictionary<string, MatchPattern>? Headers { get; set; }
}

public class MatchPattern
{
    public string? Matches { get; set; }
}

public class ResponseDefinition
{
    public int StatusCode { get; set; } = 200;
    public string? Body { get; set; }
    public Dictionary<string, string>? Headers { get; set; }
    public int Delay { get; set; }
}
