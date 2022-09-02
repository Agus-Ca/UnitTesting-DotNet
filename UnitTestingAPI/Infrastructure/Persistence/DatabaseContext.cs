using Microsoft.EntityFrameworkCore;
using UnitTestingAPI.Domain.Entities;
using UnitTestingAPI.Infrastructure.Persistence.Interfaces;

namespace UnitTestingAPI.Infrastructure.Persistence;

public partial class DatabaseContext : DbContext, IDatabaseContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; } = null!;
}