using MediatR;

namespace TaskManagement.Application.Features.TaskEntity.Commands.DeleteTaskEntity;

public class DeleteTaskEntityCommand: IRequest<Unit>
{
    public int Id { get; set; }
}
