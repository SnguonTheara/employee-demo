using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Employee.Commands;

public class DeleteEmployeeCommand: IRequest<bool>
{
    public int Id { get; set;}
}
