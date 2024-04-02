using Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Employee.Commands;

public class CreateEmployeeCommand : IRequest<Domain.Entities.Employee>
{
    public string EmployeeId { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDay { get; set; }
    public int Gender { get; set; }
}
