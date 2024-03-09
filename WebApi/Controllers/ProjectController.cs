using AutoMapper;
using Business.Projects.Commands.AddEmployeeToProject;
using Business.Projects.Commands.CreateProject;
using Business.Projects.Commands.DeleteEmployeeFromProject;
using Business.Projects.Commands.DeleteProject;
using Business.Projects.Queries.GetProjectDetails;
using Business.Projects.Queries.GetProjectList;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Project;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : BaseController
    {
        private readonly IMapper _mapper;
        public ProjectController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<ProjectListVm>> GetAll([FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate,
            [FromQuery] int? priority,
        [FromQuery] string? sortBy,
        [FromQuery] string? sortOrder)
        {
            var query = new GetProjectListQuery()
            {
                StartDate = startDate,
                EndDate = endDate,
                Priority = priority,
                SortBy = sortBy,
                SortOrder = sortOrder
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDetailsVm>> Get(int id)
        {
            var query = new GetProjectDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateProjectDto createProjectDto)
        {
            var command = _mapper.Map<CreateProjectCommand>(createProjectDto);
            var projectId = await Mediator.Send(command);
            return Ok(projectId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProjectDto updateProjectDto)
        {
            var command = _mapper.Map<UpdateProjectDto>(updateProjectDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPost("{projectId}/addEmployee/{employeeId}")]
        public async Task<IActionResult> AddEmployeeToProject(
            int projectId, string employeeId)
        {
            var command = new AddEmployeeToProjectCommand
            {
                ProjectId = projectId,
                EmployeeId = employeeId
            };
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{projectId}/removeEmployee/{employeeId}")]
        public async Task<IActionResult> RemoveEmployeeFromProject(
            int projectId, string employeeId)
        {
            var command = new DeleteEmployeeFromProjectCommand
            {
                ProjectId = projectId,
                EmployeeId = employeeId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
