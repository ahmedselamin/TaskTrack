namespace TaskTrack.Shared
{
    public class UpdateTodoDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool Status { get; set; } = false;
    }
}

