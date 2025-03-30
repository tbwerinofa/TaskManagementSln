using AutoMapper;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Exceptions;
using MediatR;

namespace TaskManagement.Application.Features.TaskEntity.Commands.CreateTaskEntity
{
    public class CreateTaskEntityCommandHandler : IRequestHandler<CreateTaskEntityCommand, int>
    {
        private readonly ITaskEntityRepository _taskEntityRepository;
        private readonly ITaskStatusEntityRepository _taskStatusEntityRepository;
        private readonly IMapper _mapper;

        public CreateTaskEntityCommandHandler(IMapper mapper, ITaskEntityRepository taskEntityRepository, ITaskStatusEntityRepository taskStatusEntityRepository)
        {
            _taskEntityRepository = taskEntityRepository;
            _taskStatusEntityRepository = taskStatusEntityRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateTaskEntityCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new CreateTaskEntityCommandValidator(_taskStatusEntityRepository);
            var validationResults = await validator.ValidateAsync(request);

            if (!validationResults.IsValid)
                throw new BadRequestException("Invalid Task", validationResults);

            //convert to domain entity object
            var TaskEntity = _mapper.Map<TaskManagament.Domain.TaskEntity>(request);
            //add to database
            await _taskEntityRepository.CreateAsync(TaskEntity);
            //return record id

            return TaskEntity.Id;
        }
    }
}
