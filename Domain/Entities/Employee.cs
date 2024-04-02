using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public sealed class Employee
{
    [Key]
    public int Id { get; set; }

    [MaxLength(8)]
    [MinLength(8)]
    public string EmployeeId { get; set; }

    [Required]
    public string FullName { get; set; }

    [Required]
    public DateTime BirthDay { get; set; }

    [Required]
    public int Gender { get; set; }
}

public enum Gender 
{
    Male = 1,
    Female = 2,
}