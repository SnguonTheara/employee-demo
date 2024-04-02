namespace WebApi.Requests
{
    public class HttpResponse<T>
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
