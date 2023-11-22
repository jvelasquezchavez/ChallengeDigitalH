using Microsoft.EntityFrameworkCore;
using Model.Entities;

public class ApplicationDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Team> Teams { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

}