using ContactManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DAL.IRepositories
{
    public interface IEmployeeRepository
    {
        public Task AddEmployees(List<Employee> employees);
        public Task<List<Employee>> GetAllEmployees();
        public Task DeleteEmployee(int id);
        public Task UpdateEmployee(Employee employee);
    }
}
