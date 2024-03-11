using AutoMapper;
using Business.Employees.Commands.UpdateEmployee;
using Business.ProjectTasks.Commands.CreateProjectTask;
using Business.ProjectTasks.Commands.DeleteProjectTask;
using Business.ProjectTasks.Commands.ReassignProjectTask;
using Business.ProjectTasks.Commands.UpdateProjectTask;
using Business.ProjectTasks.Queries.GetProjectTaskDetails;
using Business.ProjectTasks.Queries.GetProjectTaskList;
using Data.Enums;
using Microsoft.AspNetCore.Mvc;
using Front.Models.ProjectTask;

namespace Front.Controllers
{
    [Route("api/project/{projectId}/task")]
    public class ProjectTaskController : BaseController
    {
        private readonly IMapper _mapper;
        public ProjectTaskController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<ProjectTaskListVm>> GetAll(
            [FromQuery] string? authorId,
            [FromQuery] string? executorId,
            [FromQuery] Status? status,
            [FromQuery] int? priority,
            [FromQuery] string? sortBy,
            [FromQuery] string? sortOrder,
            int projectId)
        {
            var query = new GetProjectTaskListQuery()
            {
                ProjectId = projectId,
                AuthorId = authorId,
                ExecutorId = executorId,
                Status = status,
                Priority = priority,
                SortBy = sortBy,
                SortOrder = sortOrder
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectTaskDetailsVm>> Get(int projectId,int id)
        {
            var query = new GetProjectTaskDetailsQuery()
            {
                Id = id,
                ProjectId = projectId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateProjectTaskDto createProjectTaskDto)
        {
            var command = _mapper.Map<CreateProjectTaskCommand>(createProjectTaskDto);
            var projectTaskId = await Mediator.Send(command);
            return Ok(projectTaskId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProjectTaskDto updateProjectTaskDto)
        {
            var command = _mapper.Map<UpdateProjectTaskCommand>(updateProjectTaskDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProjectTaskCommand()
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut("reassign")]
        public async Task<IActionResult> ReassignTask([FromBody] ReassignProjectTaskDto reassignProjectTaskDto)
        {
            var command = new ReassignProjectTaskCommand()
            {
                TaskId = reassignProjectTaskDto.TaskId,
                ExecutorId = reassignProjectTaskDto.ExecutorId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
