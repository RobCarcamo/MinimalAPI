using System.Net;

namespace _03MinimalAPI.Contracts.Responses;

public class ErrorResponse
{
    public bool Success { get; set; } = false;
    public List<string> Errors { get; set; } = new List<string>();
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.BadRequest;
}
