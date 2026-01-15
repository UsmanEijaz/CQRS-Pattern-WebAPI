using CQRS_Pattern_WebAPI.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Pattern_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TasksController(IMediator mediator) => _mediator = mediator;

        [HttpPost("api/createTask")]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskCommand command)
        {
            var task = await _mediator.Send(command);
            return Ok(task);
        }

        [HttpPut("api/updateTask/{id}")]
        public async Task<IActionResult> UpdateTaskStatus(int id, [FromBody] UpdateTaskStatusCommand command)
        {
            if (id != command.Id) return BadRequest("Id mismatch");
            var task = await _mediator.Send(command);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpGet("api/getTask/{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            var task = await _mediator.Send(new GetTaskByIdQuery(id));
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpGet("api/getAllTask")]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _mediator.Send(new GetAllTasksQuery());
            return Ok(tasks);
        }

    }
}
