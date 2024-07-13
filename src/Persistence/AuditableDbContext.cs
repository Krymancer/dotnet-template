using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public abstract class AuditableDbContext(DbContextOptions options) : DbContext(options)
{
    public virtual async Task<int> SaveChangesAsync(string username = "SYSTEM")
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                     .Where(q => q.State is EntityState.Added or EntityState.Modified))
            if (entry.State == EntityState.Added)
                entry.Entity.CreatedDate = DateTime.Now;
            else if (entry.State == EntityState.Modified) entry.Entity.ModifiedDate = DateTime.Now;

        var result = await base.SaveChangesAsync();

        return result;
    }
}