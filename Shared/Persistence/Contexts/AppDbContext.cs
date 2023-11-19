using ActivityReview.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using ActivityReview.ActivityReview.Domain.Models;

namespace ActivityReview.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    
    public DbSet<Activity> Activities { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

       
        
        builder.Entity<Activity>().ToTable("activities_review");
        builder.Entity<Activity>().HasKey(p => p.Id);
        builder.Entity<Activity>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
       builder.Entity<Activity>().Property(p => p.Date).IsRequired();
        builder.Entity<Activity>().Property(p => p.Comment).IsRequired().HasMaxLength(100);
        builder.Entity<Activity>().Property(p => p.Score).IsRequired();
        builder.Entity<Activity>().Property(p => p.ActivityId).IsRequired();
        builder.Entity<Activity>().Property(p => p.CustomersId).IsRequired();
        builder.Entity<Activity>().Property(p => p.ActivityCode).IsRequired();
        
      

        
        // Apply Snake Case Naming Convention
        
        builder.UseSnakeCaseNamingConvention();
    }
}