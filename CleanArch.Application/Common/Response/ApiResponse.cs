namespace Application.Common.Response
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public bool Result { get; set; }
        public string Message { get; set; }
        public string Url { get; set; }
    }
}
