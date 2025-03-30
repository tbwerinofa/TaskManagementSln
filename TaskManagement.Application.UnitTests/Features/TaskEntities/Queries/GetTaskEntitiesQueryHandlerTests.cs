using AutoMapper;
using Moq;
using Shouldly;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Features.TaskEntity.Queries.GetAllTaskEntities;
using TaskManagement.Application.Logging;
using TaskManagement.Application.MappingProfiles;
using TaskManagement.Application.UnitTests.Mocks;

namespace TaskManagement.Persistence.UnitTests.Features.TaskEntities.Queries;
public class GetTaskEntitiesQueryHandlerTests
{
    private readonly Mock<ITaskEntityRepository> _mockRepo;
    private IMapper _mapper;
    private Mock<IAppLogger<GetTaskEntitiesQueryHandler>> _mockAppLogger;

    public GetTaskEntitiesQueryHandlerTests()
    {
        _mockRepo = MockTaskEntityRepository.GetMockTaskEntityRepository();
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<TaskEntityProfiles>();
        });

        _mapper = mapperConfig.CreateMapper();
        _mockAppLogger = new Mock<IAppLogger<GetTaskEntitiesQueryHandler>>();
    }

    [Fact]
    public async Task GetTaskEntitysListTest()
    {
        var handler = new GetTaskEntitiesQueryHandler(_mapper,
            _mockRepo.Object,
            _mockAppLogger.Object);

        var result = await handler.Handle(new GetTaskEntitiesQuery(), CancellationToken.None);

        result.ShouldBeOfType<List<TaskEntityDto>>();
        result.Count.ShouldBe(3);

    }
}