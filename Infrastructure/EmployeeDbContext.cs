using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System.Reflection.Metadata;

namespace Infrastructure;
public class EmployeeDbContext : DbContext
{
    public EmployeeDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Employee> Employee { get; set; }

}