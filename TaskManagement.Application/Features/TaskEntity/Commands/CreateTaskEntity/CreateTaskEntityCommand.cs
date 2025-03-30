using TaskManagement.Application.Application.Features.LeaveRequest.Shared;
using MediatR;

namespace TaskManagement.Application.Features.TaskEntity.Commands.CreateTaskEntity;

public class CreateTaskEntityCommand: BaseTaskEntity, IRequest<int>
{

}
