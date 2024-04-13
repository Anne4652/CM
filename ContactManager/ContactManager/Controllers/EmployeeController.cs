using ContactManager.BAL.IServices;
using ContactManager.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.PL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadCsv(IFormFile file)
        {
            await _employeeService.ReadEmployeesFromCsv(file);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            return Ok(await _employeeService.GetEmployees());
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployees(int id)
        {
            await _employeeService.DeleteEmployee(id);
            return Ok();
        }

        [HttpPut]

        public async Task<IActionResult> EditEmployee(Employee employee)
        {
            await _employeeService.EditEmployee(employee);
            return Ok();
        }
    }
}
