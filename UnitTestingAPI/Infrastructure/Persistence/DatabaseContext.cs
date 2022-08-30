using Microsoft.EntityFrameworkCore;
using UnitTestingAPI.Domain.Entities;

namespace UnitTestingAPI.Infrastructure.Persistence;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; } = null!;
}