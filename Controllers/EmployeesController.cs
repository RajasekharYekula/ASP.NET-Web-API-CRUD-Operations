using EmpAdminPortal.Data;
using EmpAdminPortal.Modals;
using EmpAdminPortal.Modals.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EmpAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //get all employees list
        [HttpGet]
        public IActionResult GetAllEmployees()
        {

            return Ok(dbContext.Employees.ToList());
        }

        //get employee data based on the ID
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetAllEmployeeId(Guid id)
        {
            var employee = dbContext.Employees.Find(id);

            if(employee is null)
            {
                return NotFound();
            }
            return Ok(employee);    
        }

        //Add new employee
        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto) {
            var employeeEntity = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary
            };
            dbContext.Employees.Add(employeeEntity);
            dbContext.SaveChanges();
            return Ok(employeeEntity);

        }

        //update the employeee details 
        [HttpPut]
            [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id,UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = dbContext.Employees.Find(id);
            if(employee is null)
            {
                return NotFound();
            }
            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone = updateEmployeeDto.Phone;
            employee.Salary = updateEmployeeDto.Salary;
            dbContext.SaveChanges();
            return Ok(employee);
        }

        //Delete the employee 
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = dbContext.Employees.Find(id);
            if(employee is null) 
            {
                return NotFound();
            }
            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();
            return Ok();
        }

    }
}
