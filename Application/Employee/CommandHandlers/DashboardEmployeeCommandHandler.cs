using Application.Abstractions;
using Application.Dto;
using Application.Employee.Commands;
using MediatR;

namespace Application.Employee.CommandHandlers;

public class DashboardEmployeeCommandHandler : IRequestHandler<DashboardEmployeeCommand, QueryDashboard>
{
    private readonly IEmployeeRepository _employeeRepository;

    public DashboardEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<QueryDashboard> Handle(DashboardEmployeeCommand request, CancellationToken cancellationToken)
    {
        return new QueryDashboard{
            Total = 150,
            Male = 50,
            Female = 100
        };
    }
}