using FluentValidation;
using System;

namespace WebApi.Requests;

public class UpdateEmployeeRequest
{
    public string EmployeeId { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDay { get; set; }
    public int Gender { get; set; }
}


public class UpdateEmployeeRequestValidator : AbstractValidator<UpdateEmployeeRequest>
{
    public UpdateEmployeeRequestValidator()
    {
        RuleFor(x => x.EmployeeId).NotEmpty().Length(8,8);
        RuleFor(x => x.FullName).NotNull().NotEmpty().MaximumLength(10);
        RuleFor(x => x.BirthDay).NotEmpty();
        //RuleFor(x => x.Gender).InclusiveBetween("Male", "Female");
    }
}