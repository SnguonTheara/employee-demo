using Application.Abstractions;
using Application.Employee.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employee.CommandHandlers;

public class GetEmployeeByIdCommandHandler : IRequestHandler<GetEmployeeByIdCommand, Domain.Entities.Employee>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetEmployeeByIdCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Domain.Entities.Employee> Handle(GetEmployeeByIdCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetEmployeeById(request.Id);
        return employee;
    }
}
