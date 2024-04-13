using ContactManager.BAL.IServices;
using ContactManager.DAL.Entities;
using ContactManager.DAL.IRepositories;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.BAL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task ReadEmployeesFromCsv(IFormFile file)
        {
            var employees = new List<Employee>();

            if (file != null && file.Length > 0)
            {
                using var reader = new StreamReader(file.OpenReadStream());
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    employees = csv.GetRecords<Employee>().ToList();
                }
            }
            else
            {
                throw new ArgumentException("File do not exist or empty");
            }
            await _employeeRepository.AddEmployees(employees);
        }

        public async Task EditEmployee(Employee employee)
        {
            if (this.ValidateEmployee(employee))
            {
                await _employeeRepository.UpdateEmployee(employee);
            }
            else
            {
                throw new ArgumentException("Not valid data");
            }
        }

        public async Task DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteEmployee(id);
        }

        private bool ValidateEmployee(Employee employee)
        {
            if (string.IsNullOrEmpty(employee.Name))
            {
                return false;
            }

            if (employee.DateOfBirth == default(DateTime))
            {
                return false;
            }

            if (employee.Salary <= 0)
            {
                return false;
            }

            if (!IsValidPhone(employee.Phone))
            {
                return false;
            }


            return true;
        }

        private bool IsValidPhone(string phone)
        {
            return !string.IsNullOrEmpty(phone) && phone.All(char.IsDigit);
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _employeeRepository.GetAllEmployees();
        }
    }
}
