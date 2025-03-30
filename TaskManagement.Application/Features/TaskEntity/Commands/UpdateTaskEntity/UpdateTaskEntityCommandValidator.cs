using FluentValidation;
using TaskManagement.Application.Application.Features.LeaveRequest.Shared;
using TaskManagement.Application.Contracts.Persistence;

namespace TaskManagement.Application.Features.TaskEntity.Commands.UpdateTaskEntity;

public class UpdateTaskEntityCommandValidator : AbstractValidator<UpdateTaskEntityCommand>
{
    private readonly ITaskEntityRepository _taskEntityRepository;
    private readonly ITaskStatusEntityRepository _taskStatusEntityRepository;
    public UpdateTaskEntityCommandValidator(ITaskEntityRepository taskEntityRepository,
        ITaskStatusEntityRepository taskStatusEntityRepository)
    {
        this._taskEntityRepository = taskEntityRepository;
        this._taskStatusEntityRepository = taskStatusEntityRepository;

        Include(new BaseTaskEntityValidator(_taskStatusEntityRepository));

        RuleFor(p => p.Id)
         .NotNull()
         .MustAsync(TaskEntityMustExist);
    }

    private async Task<bool> TaskEntityMustExist(int id, CancellationToken token)
    {
        var TaskEntity = await _taskEntityRepository.GetByIdAsync(id);
        return TaskEntity != null;
    }

}
