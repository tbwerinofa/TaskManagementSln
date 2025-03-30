using FluentValidation;
using TaskManagement.Application.Application.Features.LeaveRequest.Shared;
using TaskManagement.Application.Contracts.Persistence;

namespace TaskManagement.Application.Features.TaskEntity.Commands.CreateTaskEntity;

public class CreateTaskEntityCommandValidator: AbstractValidator<CreateTaskEntityCommand>
{
    private readonly ITaskStatusEntityRepository _taskStatusEntityRepository;
    public CreateTaskEntityCommandValidator(ITaskStatusEntityRepository taskStatusEntityRepository)
	{
        this._taskStatusEntityRepository = taskStatusEntityRepository;

        Include(new BaseTaskEntityValidator(_taskStatusEntityRepository));

    }

}

