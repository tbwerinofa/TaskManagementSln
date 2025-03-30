using Microsoft.EntityFrameworkCore;
using TaskManagament.Domain;
using TaskManagament.Domain.Common;
using TaskManagement.Application.Identity;

namespace TaskManagement.Persistence.DatabaseContext;
public class TaskDatabaseContext : DbContext
{
    public readonly IUserService _userService;

    public TaskDatabaseContext(DbContextOptions<TaskDatabaseContext> options, IUserService userService) : base(options)
    {
        _userService = userService;
    }
    public DbSet<TaskEntity> TaskEntities { get; set; }
    public DbSet<TaskStatusEntity> TaskStatusEntities { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskDatabaseContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
        {
            entry.Entity.DateModified = DateTime.Now;
            entry.Entity.ModifiedBy = _userService.UserId;

            if (entry.State == EntityState.Added)
            {
                entry.Entity.DateCreated = DateTime.Now;
                entry.Entity.CreatedBy = _userService.UserId;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
