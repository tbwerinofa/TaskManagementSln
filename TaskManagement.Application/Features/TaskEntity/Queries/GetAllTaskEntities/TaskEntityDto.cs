namespace TaskManagement.Application.Features.TaskEntity.Queries.GetAllTaskEntities;

public class TaskEntityDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int TaskStatusEntityId { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
}
