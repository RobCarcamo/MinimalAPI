using System.Net;

namespace _03MinimalAPI.Contracts.Responses;

public class SuccessResponse
{
    public bool Success { get; set; } = false;
    public HttpStatusCode StatusCode { get; set; }
}
