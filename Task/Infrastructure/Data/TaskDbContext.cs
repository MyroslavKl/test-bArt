using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class TaskDbContext:DbContext
{
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Incident> Incidents { get; set; }

    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>()
            .HasIndex(a => a.Name)
            .IsUnique();

        modelBuilder.Entity<Contact>()
            .HasIndex(c => c.Email)
            .IsUnique();
        
    }
}