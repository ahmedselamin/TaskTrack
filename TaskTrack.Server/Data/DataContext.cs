namespace TaskTrack.Server.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public required DbSet<User> Users { get; set; }
        public required DbSet<Todo> Todos { get; set; }
    }
}
