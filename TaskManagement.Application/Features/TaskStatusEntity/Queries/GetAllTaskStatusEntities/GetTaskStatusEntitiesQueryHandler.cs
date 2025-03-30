using AutoMapper;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Logging;
using MediatR;
using TaskManagement.Application.Features.TaskEntity.Queries.GetAllTaskEntitys;

namespace TaskManagement.Application.Features.TaskEntity.Queries.GetAllTaskEntities;

public class GetTaskStatusEntitiesQueryHandler : IRequestHandler<GetTaskStatusEntitiesQuery, List<TaskStatusEntityDto>>
{
    private readonly ITaskEntityRepository _TaskEntityRepository;
    private readonly IAppLogger<GetTaskStatusEntitiesQueryHandler> _logger;
    private readonly IMapper _mapper;

    public GetTaskStatusEntitiesQueryHandler(IMapper mapper,ITaskEntityRepository TaskEntityRepository, IAppLogger<GetTaskStatusEntitiesQueryHandler> logger)
    {
        _TaskEntityRepository = TaskEntityRepository;
        this._logger = logger;
        _mapper = mapper;
    }



    public async Task<List<TaskStatusEntityDto>> Handle(GetTaskStatusEntitiesQuery request, CancellationToken cancellationToken)
    {
        //query database
        var taskEntities =  await _TaskEntityRepository.GetAsync();

        //convert objects to dto
        var data = _mapper.Map<List<TaskStatusEntityDto>>(taskEntities);

        _logger.LogInformation("All Task Status Entities are retrieved");
        //return DTO
        return data;
    }
}
