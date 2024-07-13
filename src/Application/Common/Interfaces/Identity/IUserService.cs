using CleanArchitecture.Application.Models.Identity;

namespace Application.Common.Interfaces.Identity;

public interface IUserService
{
    Task<List<Employee>> GetEmployees();
    Task<Employee> GetEmployee(string userId);
}