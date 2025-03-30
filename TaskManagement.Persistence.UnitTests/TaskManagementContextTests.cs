using Microsoft.EntityFrameworkCore;
using Shouldly;
using TaskManagament.Domain;
using TaskManagement.Persistence.DatabaseContext;

namespace TaskManagement.Persistence.UnitTests;
public class TaskManagementContextTests
{
    private readonly TaskDatabaseContext _taskDatabaseContext;

    public TaskManagementContextTests()
    {
        var dbOptions = new DbContextOptionsBuilder<TaskDatabaseContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        _taskDatabaseContext = new TaskDatabaseContext(dbOptions);
    }

    [Fact]
    public async Task Save_SetDateCreatedValue()
    {
        //arrange
        var taskEntity = new TaskEntity { Id = 1, Title = "Interview Project", Description = "Created a to do application", TaskStatusEntityId =1 };

        //act
        _taskDatabaseContext.TaskEntities.Add(taskEntity);
        await _taskDatabaseContext.SaveChangesAsync();

        //assert
        taskEntity.DateCreated.ShouldNotBeNull();
    }

    [Fact]
    public async Task Save_SetDateModifiedValue()
    {
        //arrange
        var taskEntity = new TaskEntity { Id = 1, Title = "Interview Project", Description = "Created a to do application", TaskStatusEntityId = 1 };

        //act
        _taskDatabaseContext.TaskEntities.Add(taskEntity);
        await _taskDatabaseContext.SaveChangesAsync();

        //assert
        taskEntity.DateModified.ShouldNotBeNull();
    }
}