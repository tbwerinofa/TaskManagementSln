using MediatR;

namespace TaskManagement.Application.Features.TaskEntity.Queries.GetAllTaskEntitys;

public record GetTaskStatusEntitiesQuery: IRequest<List<TaskStatusEntityDto>>;

