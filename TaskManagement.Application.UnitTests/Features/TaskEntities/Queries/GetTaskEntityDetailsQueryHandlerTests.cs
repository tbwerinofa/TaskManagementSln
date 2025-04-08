using AutoMapper;
using Moq;
using Shouldly;
using TaskManagament.Domain;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Features.TaskEntity.Queries.GetTaskEntityDetails;
using TaskManagement.Application.MappingProfiles;

namespace TaskManagement.Application.UnitTests.Features.TaskEntities.Queries;
public class GetTaskEntityDetailsQueryHandlerTests
{
    private readonly Mock<ITaskEntityRepository> _mockRepo;
    private IMapper _mapper;


    public GetTaskEntityDetailsQueryHandlerTests()
    {
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<TaskEntityProfiles>();
        });

        _mapper = mapperConfig.CreateMapper();

        // Initialize Mock Repository
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
    }

    [Fact]
    public async Task GetTaskEntityDetail_IsSuccess_Test()
    {
        var handler = new GetTaskEntityDetailsQueryHandler(_mapper,
            _mockRepo.Object);

        var result = await handler.Handle(new GetTaskEntityDetailsQuery(1), CancellationToken.None);

        result.ShouldBeOfType<TaskEntityDetailDto>();
        result.ShouldNotBeNull();
        result.Id.ShouldBe(1);
        result.Title.ShouldBe("Interview Project");
        result.Description.ShouldBe("Created a to do application");
        result.TaskStatusEntityId.ShouldBe(3);
        result.DueDate.ShouldBeNull();
    }

}