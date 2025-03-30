using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Features.TaskEntity.Commands.CreateTaskEntity;
using TaskManagement.Application.Features.TaskEntity.Commands.DeleteTaskEntity;
using TaskManagement.Application.Features.TaskEntity.Commands.UpdateTaskEntity;
using TaskManagement.Application.Features.TaskEntity.Queries.GetAllTaskEntities;
using TaskManagement.Application.Features.TaskEntity.Queries.GetTaskEntityDetails;

namespace TaskManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class TaskEntitysController : ControllerBase
{
    private readonly IMediator _mediator;

    public TaskEntitysController(IMediator mediator)
    {
        _mediator = mediator;
    }
    // GET: TaskEntitysController

    [HttpGet]
    public async Task<List<TaskEntityDto>> Get()
    {
        var TaskEntitys = await _mediator.Send(new GetTaskEntitiesQuery());
        return TaskEntitys;
    }

    // GET api/<TaskEntitysController>/5
    [HttpGet("{id}")]
    public async Task<TaskEntityDetailDto> Get(int id)
    {
        var TaskEntity = await _mediator.Send(new GetTaskEntityDetailsQuery(id));
        return TaskEntity;
    }

    // POST api/<TaskEntitysController>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Post([FromBody] CreateTaskEntityCommand TaskEntity)
    {
        var response = await _mediator.Send(TaskEntity);
        return CreatedAtAction(nameof(Get), new { id = response });
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(400)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Put(UpdateTaskEntityCommand TaskEntity)
    {
        var response = await _mediator.Send(TaskEntity);
        return NoContent();
    }

    // DELETE api/<TaskEntitysController>/5
    [HttpDelete("{id}")]

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteTaskEntityCommand { Id = id };
        var TaskEntity = await _mediator.Send(command);
        return NoContent();
    }
}
