namespace Fit3d.BLL.Common
{
    public class ServiceResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; } = string.Empty;
    }

    public class ResponseData<T> : ServiceResponse
    {
        public T? Data { get; set; }
    }
}
