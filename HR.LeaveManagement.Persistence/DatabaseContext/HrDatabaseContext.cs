using System.Reflection;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.DatabaseContext;

public class HrDatabaseContext(DbContextOptions<HrDatabaseContext> options) : DbContext(options)
{
    public DbSet<LeaveType> LeaveTypes { get; init; }
    public DbSet<LeaveAllocation> LeaveAllocations { get; init; }
    public DbSet<LeaveRequest> LeaveRequests { get; init; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HrDatabaseContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>()
                     .Where(q => q.State is EntityState.Added or EntityState.Modified))
        {
            entry.Entity.LastModifiedDate = DateTime.Now;

            if (entry.State == EntityState.Added)
                entry.Entity.CreatedDate = DateTime.Now;
        }

        return SaveChangesAsync(true, cancellationToken);
    }
}
