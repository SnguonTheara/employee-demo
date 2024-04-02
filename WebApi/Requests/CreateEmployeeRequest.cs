using FluentValidation;
using System;

namespace WebApi.Requests;

public class CreateEmployeeRequest
{
    public string EmployeeId { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDay { get; set; }
    public int Gender { get; set; }
}


public class CreateEmployeeRequestValidator : AbstractValidator<CreateEmployeeRequest>
{
    public CreateEmployeeRequestValidator()
    {
        // RuleFor(x => x.EmployeeId).NotEmpty().Length(8,8);
        // RuleFor(x => x.FullName).NotNull().NotEmpty();
        // RuleFor(x => x.BirthDay).NotEmpty();
        //RuleFor(x => x.Gender).InclusiveBetween("Male", "Female");
    }
}