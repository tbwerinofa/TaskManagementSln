using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using TaskManagament.Domain;

namespace TaskManagement.Persistence.Repository;
public class TaskEntityRepository : GenericRepository<TaskEntity>, ITaskEntityRepository
    {
        public TaskEntityRepository(TaskDatabaseContext context) : base(context)
        {
        }
    }