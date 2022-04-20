namespace main.Models.Responses
{
    public class ResponseBase<T>
    {
        public ResponseBase()
        {
            ResponseTime = DateTime.UtcNow;
            Message = "";
        }
        public DateTime ResponseTime { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public int Count { get; set; }
    }
}
