using AutoMapper;
using MediatR;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Exceptions;

namespace TaskManagement.Application.Features.TaskEntity.Queries.GetTaskEntityDetails;

public class GetTaskEntityDetailsQueryHandler : IRequestHandler<GetTaskEntityDetailsQuery, TaskEntityDetailDto>
{
    private readonly ITaskEntityRepository _taskEntityRepository;
    private readonly IMapper _mapper;

    public GetTaskEntityDetailsQueryHandler(IMapper mapper,ITaskEntityRepository taskEntityRepository)
    {
        _taskEntityRepository = taskEntityRepository;
       _mapper = mapper;
    }



    public async Task<TaskEntityDetailDto> Handle(GetTaskEntityDetailsQuery request, CancellationToken cancellationToken)
    {
        //query database
        var taskEntity =  await _taskEntityRepository.GetByIdAsync(request.Id);

        //verify that record exists
        if (taskEntity == null)
        {
            throw new NotFoundException(nameof(taskEntity), request.Id);
        }
        //convert objects to dto
        var data = _mapper.Map<TaskEntityDetailDto>(taskEntity);

        //return DTO
        return data;
    }
}
