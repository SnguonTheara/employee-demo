using Application.Abstractions;
using Application.Dto;
using Application.Employee.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employee.CommandHandlers;

public class ListEmployeeCommandHandler : IRequestHandler<ListEmployeeCommand, object>
{
    private readonly IEmployeeRepository _employeeRepository;

    public ListEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<object> Handle(ListEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employees = await _employeeRepository.GetAll(new QueryEmployee
        {
            Query = request.Query,
            Page = request.Page,
            Limit = request.Limit
        }) ;
        return employees;
    }
}
