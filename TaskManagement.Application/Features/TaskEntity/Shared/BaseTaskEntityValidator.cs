using FluentValidation;
using TaskManagement.Application.Contracts.Persistence;

namespace TaskManagement.Application.Application.Features.LeaveRequest.Shared;

public class BaseTaskEntityValidator : AbstractValidator<BaseTaskEntity>
{

    private readonly ITaskStatusEntityRepository _taskStatusEntityRepository;
    public BaseTaskEntityValidator( ITaskStatusEntityRepository taskStatusEntityRepository)
    {
        this._taskStatusEntityRepository = taskStatusEntityRepository;


        RuleFor(p => p.Description)
          .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters");

        RuleFor(p => p.Title)
          .NotEmpty().WithMessage("{PropertyName} is required")
          .MinimumLength(1).WithMessage("{PropertyName} must be greater than 1")
          .MaximumLength(1000).WithMessage("{PropertyName} must be less than 1000");

        RuleFor(p => p.TaskStatusEntityId)
         .MustAsync(TaskStatusEntityMustExist).WithMessage("{PropertyName} is required");
    }


    private async Task<bool> TaskStatusEntityMustExist(int taskStatusEntityId, CancellationToken token)
    {
        var result = await _taskStatusEntityRepository.GetByIdAsync(taskStatusEntityId);
        return result != null;
    }

}