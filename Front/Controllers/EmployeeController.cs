﻿using AutoMapper;
using Business.Employees.Commands.CreateEmployee;
using Business.Employees.Commands.DeleteEmployee;
using Business.Employees.Commands.UpdateEmployee;
using Business.Employees.Queries.GetEmployeeDetails;
using Business.Employees.Queries.GetEmployeeList;
using Business.Employees.Queries.SearchEmployee;
using Microsoft.AspNetCore.Mvc;
using Front.Models.Employee;

namespace Front.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : BaseController
    {
        private readonly IMapper _mapper;

        public EmployeeController(IMapper mapper)
        {
            _mapper=mapper;
        }

        [HttpGet]
        public async Task<ActionResult<EmployeeListVm>> GetAll()
        {
            var query = new GetEmployeeListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDetailsVm>> Get(string id)
        {
            var query = new GetEmployeeDetailsQuery()
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<EmployeeListVm>>> Search([FromQuery] string query)
        {
            var searchQuery = new SearchEmployeeQuery()
            {
                Query = query
            };
            var employees = await Mediator.Send(searchQuery);
            return Ok(employees);
        }


        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateEmployeeDto createEmployeeDto)
        {
            var command = _mapper.Map<CreateEmployeeCommand>(createEmployeeDto);
            try
            {
                var employeeId = await Mediator.Send(command);
                return Ok(employeeId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeDto updateEmployeeDto)
        {
            var command = _mapper.Map<UpdateEmployeeCommand>(updateEmployeeDto);
            await Mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var command = new DeleteEmployeeCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return Ok();
        }
    }
}