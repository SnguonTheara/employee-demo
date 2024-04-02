using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Employee.Commands;
public class UpdateEmployeeCommand : IRequest<Domain.Entities.Employee>
{
    public int Id { get; set; }
    public string EmployeeId { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDay { get; set; }
    public int Gender { get; set; }

}
