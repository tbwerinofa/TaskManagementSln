using MediatR;

namespace TaskManagement.Application.Features.TaskEntity.Queries.GetAllTaskEntities;

public record GetTaskEntitiesQuery: IRequest<List<TaskEntityDto>>;

