using TaskManagament.Domain;

namespace TaskManagement.Application.Contracts.Persistence;
public interface ITaskStatusEntityRepository : IGenericRepository<TaskStatusEntity>
{
}