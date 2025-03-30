namespace TaskManagement.Application.Application.Features.LeaveRequest.Shared
{
    public class BaseTaskEntity
    {
        public string? Description { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;

        public int TaskStatusEntityId { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
