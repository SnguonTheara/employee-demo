using Application.Employee.CommandHandlers;
using Application.Employee.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApi.Requests;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmployeeAsync(CreateEmployeeRequest request)
        {
            var employee = await _mediator.Send(new CreateEmployeeCommand
            {
                EmployeeId = request.EmployeeId,
                FullName = request.FullName,
                Gender = request.Gender,
                BirthDay = request.BirthDay
            });
            return employee != null ? Ok(employee) : NotFound();
        }

        [HttpGet]
        public async Task<ActionResult> ListEmployee([FromQuery] QueryEmployeeRequest request)
        {
            var employees = await _mediator.Send(new ListEmployeeCommand
            {
                Query = request.Query,  
                Page = request.Page,
                Limit = request.Limit,
            });

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployeeById(int id)
        {
            var employee = await _mediator.Send(new GetEmployeeByIdCommand
            {
                Id = id
            });
            if(employee.Id <= 0 ) {
                return NotFound(new HttpResponse<object>
                {
                    Code = HttpStatusCode.NotFound.ToString(),
                    Message = "Employee not found"
                });
            }
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id) {
            var employee = await _mediator.Send(new DeleteEmployeeCommand
            {
                Id = id
            });
            return Ok(new HttpResponse<object>
                {
                    Code = "OK",
                    Message = "Employee deleted"
                });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, UpdateEmployeeRequest request) {
            var employee = await _mediator.Send(new UpdateEmployeeCommand
            {
                Id = id,
                EmployeeId = request.EmployeeId,
                FullName = request.FullName,
                Gender = request.Gender,
                BirthDay = request.BirthDay
            });
            return employee != null ? Ok(employee) : NotFound();
        }
    }
}
