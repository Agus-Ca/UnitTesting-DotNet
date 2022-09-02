using Microsoft.EntityFrameworkCore;
using UnitTestingAPI.Domain.Entities;

namespace UnitTestingAPI.Infrastructure.Persistence.Interfaces;

public interface IDatabaseContext
{
    DbSet<Product> Products { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}