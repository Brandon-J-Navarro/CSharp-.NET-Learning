using Globomantics.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Globomantics.Infrastructure.Data;

public class GlobomanticsDbContext : DbContext
{
    public DbSet<TodoTask> TodoTasks { get; set; }
    public DbSet<Bug> Bugs { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Image> Images { get; set; }
    private static readonly IConfiguration _configuration = Startup.BuildConfiguation();
    private static string _connectionString = _configuration["ConnectionString:sqlConnectionString"];
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
        //optionsBuilder.UseSqlite("Data Source=Globomantics.db");
    }
}
