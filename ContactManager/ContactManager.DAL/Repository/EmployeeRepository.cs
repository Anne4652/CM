using ContactManager.DAL.Data;
using ContactManager.DAL.Entities;
using ContactManager.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DAL.Repository
{
    public class EmployeeRepository(ContactManagerContext dbContext) : IEmployeeRepository
    {
        private readonly ContactManagerContext _dbContext = dbContext;

        public async Task AddEmployees(List<Employee> employees)
        {
            await _dbContext.AddRangeAsync(employees);
            _dbContext.SaveChanges();
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);

            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                _dbContext.SaveChanges();
            }
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task UpdateEmployee(Employee employee)
        {
            var existingEmployee = await _dbContext.Employees.FindAsync(employee.Id);

            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.DateOfBirth = employee.DateOfBirth;
                existingEmployee.Married = employee.Married;
                existingEmployee.Phone = employee.Phone;
                existingEmployee.Salary = employee.Salary;

                _dbContext.SaveChanges();
            }
        }
    }
}
