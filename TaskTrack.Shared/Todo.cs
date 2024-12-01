namespace TaskTrack.Shared
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool status { get; set; } = false;
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
