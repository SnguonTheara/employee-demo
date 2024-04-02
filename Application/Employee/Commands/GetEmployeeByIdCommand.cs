using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employee.Commands;

public class GetEmployeeByIdCommand : IRequest<Domain.Entities.Employee>
{
    public int Id { get; set; } 
}
