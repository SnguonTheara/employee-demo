using Application.Abstractions;
using Application.Employee.Commands;
using MediatR;

namespace Application.Employee.CommandHandlers;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Domain.Entities.Employee>
{
    private readonly IEmployeeRepository _employeeRepository;

    public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Domain.Entities.Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = new Domain.Entities.Employee
        {
            EmployeeId = request.EmployeeId,
            FullName = request.FullName,
            BirthDay = request.BirthDay,
            Gender = request.Gender,
        };

        return await _employeeRepository.AddEmployee(employee);
    }
}