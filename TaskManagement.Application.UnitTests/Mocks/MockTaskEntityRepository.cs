using Moq;
using TaskManagament.Domain;
using TaskManagement.Application.Contracts.Persistence;

namespace TaskManagement.Application.UnitTests.Mocks;
public class MockTaskEntityRepository
{
    public static Mock<ITaskEntityRepository> GetMockTaskEntityRepository()
    {

        var taskStatusEntities = new List<TaskEntity>
    {
        new TaskEntity {  Id = 1, Title = "Interview Project", Description = "Created a to do application", TaskStatusEntityId = 3  },
        new TaskEntity {  Id = 2, Title = "Interview Project", Description = "Created a to do application", TaskStatusEntityId = 1  },
        new TaskEntity {  Id = 3, Title = "Interview Project", Description = "Created a to do application", TaskStatusEntityId = 2  }
    };

        var mockRepo = new Mock<ITaskEntityRepository>();

        mockRepo.Setup(repo => repo.GetAsync())
            .ReturnsAsync(taskStatusEntities);

        mockRepo.Setup(r => r.CreateAsync(It.IsAny<TaskEntity>()))
            .Returns((TaskEntity taskEntity) =>
            {
                taskStatusEntities.Add(taskEntity);
                return Task.FromResult(taskEntity); ;
            });

        return mockRepo;
    }
}
