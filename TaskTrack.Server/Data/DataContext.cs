namespace TaskTrack.Server.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
    }
}
