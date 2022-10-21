namespace REST_API_.Net_Core.Models
{
    public class ResponseModel<T>
    {
        public bool Success { get; set; }
        public T Result { get; set; }
        public string Message { get; set; }
    }
}

