using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions;
using Application.Employee.Commands;
using MediatR;

namespace Application.Employee.CommandHandlers;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Domain.Entities.Employee>
{
    private readonly IEmployeeRepository _employeeRepository;

    public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Domain.Entities.Employee> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = new Domain.Entities.Employee {
            Id = request.Id,
            EmployeeId = request.EmployeeId,
            FullName = request.FullName,
            BirthDay = request.BirthDay,
            Gender = request.Gender,
        };
        return await _employeeRepository.UpdateEmployee(employee);
    }
}
