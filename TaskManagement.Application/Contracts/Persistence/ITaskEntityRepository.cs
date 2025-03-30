using TaskManagament.Domain;

namespace TaskManagement.Application.Contracts.Persistence;
public interface ITaskEntityRepository : IGenericRepository<TaskEntity>
{
}