using AutoMapper;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Logging;
using MediatR;
using TaskManagement.Application.Features.TaskEntity.Queries.GetAllTaskEntitys;

namespace TaskManagement.Application.Features.TaskEntity.Queries.GetAllTaskEntities;

public class GetTaskStatusEntitiesQueryHandler : IRequestHandler<GetTaskStatusEntitiesQuery, List<TaskStatusEntityDto>>
{
    private readonly ITaskStatusEntityRepository _taskStatusEntityRepository;
    private readonly IAppLogger<GetTaskStatusEntitiesQueryHandler> _logger;
    private readonly IMapper _mapper;

    public GetTaskStatusEntitiesQueryHandler(IMapper mapper,ITaskStatusEntityRepository taskStatusEntityRepository, IAppLogger<GetTaskStatusEntitiesQueryHandler> logger)
    {
        _taskStatusEntityRepository = taskStatusEntityRepository;
        this._logger = logger;
        _mapper = mapper;
    }



    public async Task<List<TaskStatusEntityDto>> Handle(GetTaskStatusEntitiesQuery request, CancellationToken cancellationToken)
    {
        //query database
        var taskEntities =  await _taskStatusEntityRepository.GetAsync();

        //convert objects to dto
        var data = _mapper.Map<List<TaskStatusEntityDto>>(taskEntities);

        _logger.LogInformation("All Task Status Entities are retrieved");
        //return DTO
        return data;
    }
}
