using MediatR;

namespace TaskManagement.Application.Features.TaskEntity.Queries.GetTaskEntityDetails;

public record GetTaskEntityDetailsQuery(int Id) : IRequest<TaskEntityDetailDto>{}

