using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagament.Domain;

namespace TaskManagement.Persistence.Configurations;

public class TaskStatusEntityConfigurations : IEntityTypeConfiguration<TaskStatusEntity>
{
    public void Configure(EntityTypeBuilder<TaskStatusEntity> modelBuilder)
    {

        var taskStatusEntityList = new List<TaskStatusEntity> {
            new TaskStatusEntity{
                Id = 1,
                Name = "To Do"
                },
            new TaskStatusEntity{
                Id = 2,
                Name = "In Progress",
                },
            new TaskStatusEntity{
                Id = 3,
                Name = "Done"
                }
        };

        modelBuilder.HasData(
            taskStatusEntityList);

        modelBuilder.Property(q => q.Name).IsRequired().HasMaxLength(100);

    }
}