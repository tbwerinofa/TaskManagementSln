using TaskManagament.Domain.Common;

namespace TaskManagament.Domain
{
    public class TaskStatusEntity : BaseEntity
    {
        public TaskStatusEntity()
        {
            this.TaskEntities = [];
        }

        public string Name { get; set; }
        public virtual ICollection<TaskEntity> TaskEntities { get; set; }
    }
}
