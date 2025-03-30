using MediatR;
using TaskManagement.Application.Application.Features.LeaveRequest.Shared;

namespace TaskManagement.Application.Features.TaskEntity.Commands.UpdateTaskEntity;

public class UpdateTaskEntityCommand: BaseTaskEntity, IRequest<Unit>
{
    public int Id { get; set; }

}