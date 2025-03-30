using AutoMapper;
using MediatR;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Exceptions;

namespace TaskManagement.Application.Features.TaskEntity.Queries.GetTaskEntityDetails;

public class GetTaskEntityDetailsQueryHandler : IRequestHandler<GetTaskEntityDetailsQuery, TaskEntityDetailDto>
{
    private readonly ITaskEntityRepository _TaskEntityRepository;
    private readonly IMapper _mapper;

    public GetTaskEntityDetailsQueryHandler(IMapper mapper,ITaskEntityRepository TaskEntityRepository)
    {
        _TaskEntityRepository = TaskEntityRepository;
       _mapper = mapper;
    }



    public async Task<TaskEntityDetailDto> Handle(GetTaskEntityDetailsQuery request, CancellationToken cancellationToken)
    {
        //query database
        var TaskEntity =  await _TaskEntityRepository.GetByIdAsync(request.Id);

        //verify that record exists
        if (TaskEntity == null)
        {
            throw new NotFoundException(nameof(TaskEntity), request.Id);
        }
        //convert objects to dto
        var data = _mapper.Map<TaskEntityDetailDto>(TaskEntity);

        //return DTO
        return data;
    }
}
