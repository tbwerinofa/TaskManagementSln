using AutoMapper;
using MediatR;
using Moq;
using Shouldly;
using TaskManagament.Domain;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Features.TaskEntity.Commands.DeleteTaskEntity;
using TaskManagement.Application.Features.TaskEntity.Commands.UpdateTaskEntity;
using TaskManagement.Application.Features.TaskEntity.Queries.GetAllTaskEntities;
using TaskManagement.Application.Features.TaskEntity.Queries.GetTaskEntityDetails;
using TaskManagement.Application.Logging;
using TaskManagement.Application.MappingProfiles;
using TaskManagement.Application.UnitTests.Mocks;

namespace TaskManagement.Application.UnitTests.Features.TaskEntities.Commands;
public class DeleteTaskEntityCommandHandlerTests
{
    private readonly Mock<ITaskEntityRepository> _mockRepo;
    private IMapper _mapper;

    public DeleteTaskEntityCommandHandlerTests()
    {
        _mockRepo = MockTaskEntityRepository.GetMockTaskEntityRepository();
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<TaskEntityProfiles>();
        });

        _mapper = mapperConfig.CreateMapper();
        _mockRepo = new Mock<ITaskEntityRepository>();

        // Setup mock repository to return a valid taskEntity for ID 1
        _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(new TaskEntity
        {
            Id = 1,
            Title = "Interview Project",
            Description = "Created a to do application",
            TaskStatusEntityId = 3,
            DueDate = null
        });
        // Setup mock repository to return a valid taskEntity for ID 1
        _mockRepo.Setup(repo => repo.DeleteAsync(It.IsAny<TaskEntity>()));

    }


    [Fact]
    public async Task DeleteTaskEntity_IsSuccess_Test()
    {
        var handler = new DeleteTaskEntityCommandHandler(_mapper,
            _mockRepo.Object);

        var deleteTaskEntityCommand = new DeleteTaskEntityCommand
        {
            Id = 1
        };

        var result = await handler.Handle(deleteTaskEntityCommand, CancellationToken.None);

        result.ShouldBe(Unit.Value);

    }
}