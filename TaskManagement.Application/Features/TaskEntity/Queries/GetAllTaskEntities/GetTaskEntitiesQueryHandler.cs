using AutoMapper;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Logging;
using MediatR;

namespace TaskManagement.Application.Features.TaskEntity.Queries.GetAllTaskEntities;

public class GetTaskEntitiesQueryHandler : IRequestHandler<GetTaskEntitiesQuery, List<TaskEntityDto>>
{
    private readonly ITaskEntityRepository _TaskEntityRepository;
    private readonly IAppLogger<GetTaskEntitiesQueryHandler> _logger;
    private readonly IMapper _mapper;

    public GetTaskEntitiesQueryHandler(IMapper mapper,ITaskEntityRepository TaskEntityRepository, IAppLogger<GetTaskEntitiesQueryHandler> logger)
    {
        _TaskEntityRepository = TaskEntityRepository;
        this._logger = logger;
        _mapper = mapper;
    }



    public async Task<List<TaskEntityDto>> Handle(GetTaskEntitiesQuery request, CancellationToken cancellationToken)
    {
        //query database
        var TaskEntities =  await _TaskEntityRepository.GetAsync();

        //convert objects to dto
        var data = _mapper.Map<List<TaskEntityDto>>(TaskEntities);

        _logger.LogInformation("All Leave Types are retrieved");
        //return DTO
        return data;
    }
}
