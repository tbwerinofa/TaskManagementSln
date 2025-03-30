using Microsoft.EntityFrameworkCore;
using TaskManagament.Domain;
using TaskManagament.Domain.Common;

namespace TaskManagement.Persistence.DatabaseContext;
public class TaskDatabaseContext : DbContext
    {
        public TaskDatabaseContext(DbContextOptions<TaskDatabaseContext> options) : base(options)
        {


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
            foreach (var entity in base.ChangeTracker.Entries<BaseEntity>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                entity.Entity.DateModified = DateTime.Now;

                if (entity.State == EntityState.Added)
                {
                    entity.Entity.DateCreated = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
