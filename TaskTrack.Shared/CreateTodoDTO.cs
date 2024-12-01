namespace TaskTrack.Shared
{
    public class CreateTodoDTO
    {
        public string Title { get; set; } = string.Empty;
        public bool Status { get; set; } = false;
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
