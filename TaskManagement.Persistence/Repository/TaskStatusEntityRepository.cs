using TaskManagament.Domain;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Persistence.DatabaseContext;

namespace TaskManagement.Persistence.Repository;
public class TaskStatusEntityRepository : GenericRepository<TaskStatusEntity>, ITaskStatusEntityRepository
    {
        public TaskStatusEntityRepository(TaskDatabaseContext context) : base(context)
        {
        }

    }

