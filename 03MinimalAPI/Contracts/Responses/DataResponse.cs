using System.Net;

namespace _03MinimalAPI.Contracts.Responses;

public class DataResponse<TData>
{
    public bool Success { get; set; } = false;
    public TData Data { get; set; }
    public HttpStatusCode StatusCode { get; set; }
}
