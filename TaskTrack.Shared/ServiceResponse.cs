namespace TaskTrack.Shared
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public string Message { get; set; } = "Successfull";
        public bool Success { get; set; } = true;
    }
}
