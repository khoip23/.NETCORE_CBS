public class HttpResponseModel<T>
{
    public DateTime dateTime { get; set; } = DateTime.Now;
    public T data { get; set; }
}
