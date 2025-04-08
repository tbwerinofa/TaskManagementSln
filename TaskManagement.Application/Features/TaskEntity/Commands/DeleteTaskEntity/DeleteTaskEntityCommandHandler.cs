using AutoMapper;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Exceptions;
using MediatR;

namespace TaskManagement.Application.Features.TaskEntity.Commands.DeleteTaskEntity
{
    public class DeleteTaskEntityCommandHandler : IRequestHandler<DeleteTaskEntityCommand, Unit>
    {
        private readonly ITaskEntityRepository _taskEntityRepository;


        public DeleteTaskEntityCommandHandler(IMapper mapper, ITaskEntityRepository taskEntityRepository)
        {
            _taskEntityRepository = taskEntityRepository;
        }

        public async Task<Unit> Handle(DeleteTaskEntityCommand request, CancellationToken cancellationToken)
        {
            //retrieve domain entity object
            var taskEntity = await _taskEntityRepository.GetByIdAsync(request.Id);

            //verify that record exists
            if (taskEntity == null)
            {
                throw new NotFoundException(nameof(taskEntity), request.Id);
            }

            //remove from db
            await _taskEntityRepository.DeleteAsync(taskEntity);
            //return record id

            return Unit.Value;
        }
    }
}
