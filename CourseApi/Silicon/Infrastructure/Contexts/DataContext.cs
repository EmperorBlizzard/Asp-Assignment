using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<CourseEntity> Courses { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<CourseDescriptionEntity> CourseDescriptions { get; set; }
    public DbSet<CourseIncludeEntity> CourseIncludes { get; set; }
    public DbSet<CourseLearnEntity> CourseLearns { get; set; }
    public DbSet<ProgramDetailsEntity> ProgramDetails { get; set; }
    public DbSet<AuthorDescriptionEntity> AuthorDescriptions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CourseIncludeEntity>().HasKey(x => new
        {
            x.Id,
            x.CourseId,
        });

        modelBuilder.Entity<CourseLearnEntity>().HasKey(x => new
        {
            x.Id,
            x.CourseId
        });

        modelBuilder.Entity<ProgramDetailsEntity>().HasKey(x => new
        {
            x.Id,
            x.CourseId
        });
    }
}
