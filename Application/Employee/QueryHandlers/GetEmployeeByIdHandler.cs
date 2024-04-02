using Application.Abstractions;
using Application.Employee.Queries;
using MediatR;

namespace Application.Employee.QueryHandlers;

public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeById, Domain.Entities.Employee>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetEmployeeByIdHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Domain.Entities.Employee> Handle(GetEmployeeById request, CancellationToken cancellationToken)
    {
        return await _employeeRepository.GetEmployeeById(request.Id);
    }

   
}
