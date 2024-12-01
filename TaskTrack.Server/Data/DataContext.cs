namespace TaskTrack.Server.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public required DbSet<User> Users { get; set; }
    }
}
