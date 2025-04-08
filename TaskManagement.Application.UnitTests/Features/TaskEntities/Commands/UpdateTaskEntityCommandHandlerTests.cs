using AutoMapper;
using Moq;
using Shouldly;
using TaskManagament.Domain;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Features.TaskEntity.Commands.UpdateTaskEntity;
using TaskManagement.Application.Features.TaskEntity.Queries.GetAllTaskEntities;
using TaskManagement.Application.Features.TaskEntity.Queries.GetTaskEntityDetails;
using TaskManagement.Application.Logging;
using TaskManagement.Application.MappingProfiles;
using TaskManagement.Application.UnitTests.Mocks;

namespace TaskManagement.Application.UnitTests.Features.TaskEntities.Commands;
public class UpdateTaskEntityCommandHandlerTests
{
    private readonly Mock<ITaskEntityRepository> _mockRepo;
    private readonly Mock<ITaskStatusEntityRepository> _mockTaskStatusRepo;
    private Mock<IAppLogger<GetTaskEntitiesQueryHandler>> _mockAppLogger;
    private IMapper _mapper;


    public UpdateTaskEntityCommandHandlerTests()
    {
        _mockRepo = MockTaskEntityRepository.GetMockTaskEntityRepository();
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<TaskEntityProfiles>();
        });

        _mapper = mapperConfig.CreateMapper();
        _mockAppLogger = new Mock<IAppLogger<GetTaskEntitiesQueryHandler>>();

        _mockRepo = new Mock<ITaskEntityRepository>();

        // Setup mock repository to return a valid taskEntity for ID 1
        _mockRepo.Setup(repo => repo.GetByIdAsync(2)).ReturnsAsync(new TaskEntity
        {
            Id = 2,
            Title = "Interview Project",
            Description = "Created a to do application",
            TaskStatusEntityId = 3,
            DueDate = null
        });

        _mockTaskStatusRepo = new Mock<ITaskStatusEntityRepository>();

        SetUpMockTaskStatusEntityRepository();

    }


    [Fact]
    public async Task UpdateTaskEntity_IsSuccess_Test()
    {
        var handler = new UpdateTaskEntityCommandHandler(_mapper,
            _mockRepo.Object,
            _mockTaskStatusRepo.Object,
            _mockAppLogger.Object);

        var updateTaskEntityCommand = new UpdateTaskEntityCommand
        {
            Id = 2,
            Title = "April Task",
            Description = "Update task management application",
            TaskStatusEntityId = 3,
            DueDate = null
        };

        var result = await handler.Handle(updateTaskEntityCommand, CancellationToken.None);
        
        var databaseEntity = await GetTaskEntityDetailById(updateTaskEntityCommand.Id);

        databaseEntity.Id.ShouldBe(2);
        databaseEntity.Title.ShouldBe("April Task");
        databaseEntity.Description.ShouldBe("Update task management application");
        databaseEntity.TaskStatusEntityId.ShouldBe(3);

    }


    private async Task<TaskEntityDetailDto> GetTaskEntityDetailById(int id)
    {
        var gethandler = new GetTaskEntityDetailsQueryHandler(_mapper,
     _mockRepo.Object);

        var result = await gethandler.Handle(new GetTaskEntityDetailsQuery(id), CancellationToken.None);

        return result;

    }
    private void SetUpMockTaskStatusEntityRepository()
    {
        _mockTaskStatusRepo.Setup(repo => repo.GetByIdAsync(3)).ReturnsAsync(new TaskStatusEntity
        {
            Id = 3,
            Name = "Done"
        });
    }
}