using Application.Abstractions;
using Application.Dto;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly EmployeeDbContext _context;   
    public EmployeeRepository(EmployeeDbContext context)
    {
        _context = context;
    }

    public async Task<Employee> AddEmployee(Employee toCreate)
    {
        _context.Employee.Add(toCreate);
        await _context.SaveChangesAsync();

        return toCreate;
    }

    public async Task DeleteEmployee(int id)
    {
        var employee = _context.Employee.FirstOrDefault(p => p.Id == id);
        if (employee is null) return;

        _context.Employee.Remove(employee);
        await _context.SaveChangesAsync();
    }

    public async Task<object> GetAll(QueryEmployee request)
    {
        var employeeQuery = _context.Employee.AsQueryable();
        employeeQuery = employeeQuery.OrderByDescending(e => e.Id);
        if(!string.IsNullOrEmpty(request.Query) && employeeQuery is not null) {
            employeeQuery = employeeQuery.Where(e => e.FullName.ToLower().Contains(request.Query.ToLower()));
        }

        int totalNumber = employeeQuery.Count();

        List<Employee> paginetedItems = await employeeQuery
                        .Skip((request.Page - 1) * totalNumber)
                        .Take(request.Limit)
                        .ToListAsync();

        var response = new
        {
            Total = totalNumber,
            Page = request.Page,
            Limit = request.Limit,
            Data = paginetedItems
        };

        return response;
    }

    public async Task<Employee> GetEmployeeById(int id)
    {
        var employee = await _context.Employee.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        if (employee is null) return new Employee { };
        return employee;

    }

    public async Task<Employee> UpdateEmployee(Employee employee)
    {
        var _employee = await _context.Employee.FirstOrDefaultAsync(p => p.Id == employee.Id);
        if (_employee is null) return new Employee { };
        _employee.FullName = employee.FullName;
        _employee.BirthDay = employee.BirthDay;
        _employee.Gender = employee.Gender;
        _employee.EmployeeId = employee.EmployeeId;
        await _context.SaveChangesAsync();
        return _employee;
    }
}