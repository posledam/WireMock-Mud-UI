namespace WireMockUI.Models;

public class WireMockRequest
{
    public Guid Guid { get; set; }
    public string? Method { get; set; }
    public string? Url { get; set; }
    public string? AbsoluteUrl { get; set; }
    public DateTime DateTime { get; set; }
    public string? Body { get; set; }
    public Dictionary<string, string[]>? Headers { get; set; }
    public Dictionary<string, string[]>? Cookies { get; set; }
    public string? ClientIP { get; set; }
}

public class RequestsList
{
    public WireMockRequest[]? Requests { get; set; }
}
