using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Features.TaskEntity.Queries.GetAllTaskEntitys;

namespace TaskManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskStatusController : Controller
{
    private readonly IMediator _mediator;

    public TaskStatusController(IMediator mediator)
    {
        _mediator = mediator;
    }
    // GET: TaskStatusEntitysController

    [HttpGet]
    public async Task<List<TaskStatusEntityDto>> Get()
    {
        var taskStatusEntities = await _mediator.Send(new GetTaskStatusEntitiesQuery());
        return taskStatusEntities;
    }
}
