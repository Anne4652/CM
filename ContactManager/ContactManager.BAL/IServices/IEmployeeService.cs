using ContactManager.DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.BAL.IServices
{
    public interface IEmployeeService
    {
        public Task ReadEmployeesFromCsv(IFormFile file);
        public Task EditEmployee(Employee employee);
        public Task DeleteEmployee(int id);
        public Task<List<Employee>> GetEmployees();
    }
}
