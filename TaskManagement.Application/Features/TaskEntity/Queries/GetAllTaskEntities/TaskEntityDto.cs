namespace TaskManagement.Application.Features.TaskEntity.Queries.GetAllTaskEntities;

public class TaskEntityDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
}
