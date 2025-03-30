using AutoMapper;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Exceptions;
using TaskManagement.Application.Features.TaskEntity.Commands.CreateTaskEntity;
using TaskManagement.Application.Features.TaskEntity.Queries.GetAllTaskEntities;
using TaskManagement.Application.Logging;
using MediatR;

namespace TaskManagement.Application.Features.TaskEntity.Commands.UpdateTaskEntity
{
    public class UpdateTaskEntityCommandHandler : IRequestHandler<UpdateTaskEntityCommand, Unit>
    {
        private readonly ITaskEntityRepository _taskEntityRepository;
        private readonly ITaskStatusEntityRepository _taskStatusEntityRepository;
        private readonly IAppLogger<GetTaskEntitiesQueryHandler> _logger;
        private readonly IMapper _mapper;

        public UpdateTaskEntityCommandHandler(IMapper mapper,
            ITaskEntityRepository taskEntityRepository,
            ITaskStatusEntityRepository taskStatusEntityRepository,
            IAppLogger<GetTaskEntitiesQueryHandler> logger)
        {
            _taskEntityRepository = taskEntityRepository;
            this._taskStatusEntityRepository = taskStatusEntityRepository;
            this._logger = logger;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTaskEntityCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new UpdateTaskEntityCommandValidator(_taskEntityRepository, _taskStatusEntityRepository);
            var validationResults = await validator.ValidateAsync(request);

            if (!validationResults.IsValid)
            {
                _logger.LogWarning("Validation update request for {0} - {1}", nameof(TaskManagament.Domain.TaskEntity), request.Id);
                throw new BadRequestException("Invalid leave type", validationResults);
            }

            //convert to domain entity object
            var TaskEntity = _mapper.Map<TaskManagament.Domain.TaskEntity>(request);
            //add to database
            await _taskEntityRepository.UpdateAsync(TaskEntity);
            //return record id

            return Unit.Value;
        }
    }
}
