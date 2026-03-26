namespace Client.Models
{
    public class ApiEnvelope<T>
    {
        public bool success { get; set; }
        public T data { get; set; }
        public string message { get; set; }
    }
}
