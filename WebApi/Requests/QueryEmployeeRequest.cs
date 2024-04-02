namespace WebApi.Requests;

public class QueryEmployeeRequest
{
    public string? Query { get; set;  } = string.Empty;
    public int Page { get; set; } = 1;
    public int Limit { get; set; } = 25;
}
