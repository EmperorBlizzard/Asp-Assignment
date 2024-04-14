using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Contexts;

public class ApiContext(DbContextOptions<ApiContext> options) : DbContext(options)
{
    public DbSet<ContactEntity> Contacts { get; set; }
    public DbSet<ServiceEntity> Services { get; set; }
}
