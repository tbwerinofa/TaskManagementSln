using TaskManagament.Domain.Common;

namespace TaskManagament.Domain;

public class TaskEntity : BaseEntity
{

    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }

    public int TaskStatusEntityId { get; set; }
    public virtual TaskStatusEntity TaskStatusEntity { get; set; }
    public DateTime? DueDate { get; set; }
};
