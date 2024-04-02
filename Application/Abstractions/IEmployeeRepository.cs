using Application.Dto;
using Domain.Entities;

namespace Application.Abstractions;
public interface IEmployeeRepository
{
    Task<object> GetAll(QueryEmployee request);

    Task<Domain.Entities.Employee> GetEmployeeById(int id);

    Task<Domain.Entities.Employee> AddEmployee(Domain.Entities.Employee toCreate);

    Task<Domain.Entities.Employee> UpdateEmployee(Domain.Entities.Employee employee);

    Task DeleteEmployee(int id);
}