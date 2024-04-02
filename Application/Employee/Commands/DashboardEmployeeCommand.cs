using Application.Dto;
using MediatR;

namespace Application.Employee.Commands;
public class DashboardEmployeeCommand : IRequest<QueryDashboard>
{}
