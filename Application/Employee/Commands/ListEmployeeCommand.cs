using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employee.Commands;

public class ListEmployeeCommand: IRequest<object>
{
    public string Query { get; set; }   
    public int Page { get; set; }
    public int Limit { get; set; }    
}
