using AutoMapper;
using Moq;
using Shouldly;
using TaskManagament.Domain;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Features.TaskEntity.Commands.CreateTaskEntity;
using TaskManagement.Application.Features.TaskEntity.Queries.GetAllTaskEntities;
using TaskManagement.Application.Logging;
using TaskManagement.Application.MappingProfiles;
using TaskManagement.Application.UnitTests.Mocks;

namespace TaskManagement.Application.UnitTests.Features.TaskEntities.Commands;
public class CreateTaskEntityCommandHandlerTests
{
    private readonly Mock<ITaskEntityRepository> _mockRepo;
    private readonly Mock<ITaskStatusEntityRepository> _mockTaskStatusRepo;
    private Mock<IAppLogger<GetTaskEntitiesQueryHandler>> _mockAppLogger;
    private IMapper _mapper;


    public CreateTaskEntityCommandHandlerTests()
    {
        _mockRepo = MockTaskEntityRepository.GetMockTaskEntityRepository();
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<TaskEntityProfiles>();
        });

        _mapper = mapperConfig.CreateMapper();
        _mockAppLogger = new Mock<IAppLogger<GetTaskEntitiesQueryHandler>>();
        _mockTaskStatusRepo = new Mock<ITaskStatusEntityRepository>();

        SetUpMockTaskStatusEntityRepository();

    }

    [Fact]
    public async Task CreateTaskEntity_IsSuccess_Test()
    {
        var handler = new CreateTaskEntityCommandHandler(_mapper,
            _mockRepo.Object,
            _mockTaskStatusRepo.Object);

        var createTaskEntityCommand = new CreateTaskEntityCommand
        {
            Title = "April Task",
            Description = "Redo task management application",
            TaskStatusEntityId = 3,
            DueDate = null
        };

        var result = await handler.Handle(createTaskEntityCommand, CancellationToken.None);
        var taskEntityList = await GetTaskEntitysListTest();

        taskEntityList.Count.ShouldBe(4);

    }


    private async Task<List<TaskEntityDto>> GetTaskEntitysListTest()
    {
        var handler = new GetTaskEntitiesQueryHandler(_mapper,
            _mockRepo.Object,
            _mockAppLogger.Object);

        var result = await handler.Handle(new GetTaskEntitiesQuery(), CancellationToken.None);

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