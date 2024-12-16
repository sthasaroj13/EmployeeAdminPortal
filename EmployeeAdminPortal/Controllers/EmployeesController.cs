using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
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
        [HttpGet]
         public     IActionResult GetAllEmployees()
        {
            var allEmployee =dbContext.Employees.ToList();
            return Ok(allEmployee);
            //or we can write one line code to 
            //return Ok(dbConetext1.Employees.ToList()); 

        }
        [HttpPost]
        public IActionResult addEmployee(AddEmployeeDto addEmployeeDto)
        /*The method accepts an AddEmployeeDto object as input.
            employeeDto is a Data Transfer Object (DTO) that holds the employee data sent by the user.*/
        {

            /*A new Employee object (employeEnitity) is created.
           The data from employeeDto is copied into the Employee object.
            Why do this?

          The DTO is used to limit the data the user can send, while the Employee entity represents the full database table structure.
          It’s a security measure to ensure users can only send data you allow.*/

            var employeeEntity = new Employee() {
                Email = addEmployeeDto.Email,
                Name = addEmployeeDto.Name,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary,
            
            };

            dbContext.Employees.Add(employeeEntity);
            dbContext.SaveChanges();
            return Ok(employeeEntity);
        }
        [HttpGet]
        [Route("{id:guid}")]
        //this is the  code to get single employee api

        public IActionResult getEmployee(Guid id)
        {

            var employee = dbContext.Employees.Find(id);
            if (employee is null)
            {
                return BadRequest("user is not found");
            }
            
            return Ok(employee);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult updateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)

        {
            var employee = dbContext.Employees.Find(id);
            if(employee is null)
            {
                return BadRequest("user is not found");
            }

            employee.Email = updateEmployeeDto.Email;
            employee.Name = updateEmployeeDto.Name;
            employee.Phone = updateEmployeeDto.Phone;
            employee.Salary = updateEmployeeDto.Salary;
            dbContext.SaveChanges();


           return Ok(employee);

        }
        [HttpDelete]
        [Route("{id:guid}")]

        public IActionResult deleteEmployee(Guid id) {
            var employee = dbContext.Employees.Find(id);

            if (employee is null) {
                return BadRequest("user is not found");
                    }

            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();
            return Ok(employee);
        }
    }
}
