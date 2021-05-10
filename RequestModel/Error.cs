namespace RequestModel
{
    public class Error<T>
    {
        public string Message { get; set; }
        public string Exception { get; set; }
        public T Request { get; set; }
        public string Response { get; set; }
    }
}