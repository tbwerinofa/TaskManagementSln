namespace TaskManagement.Application.Features.TaskEntity.Queries.GetAllTaskEntitys;

public class TaskStatusEntityDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
}
