using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleInmemoryCrud.DbData;
using SampleInmemoryCrud.Model;

namespace SampleInmemoryCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly EmployeApiDbContext dbContext;
        public EmployeeController(EmployeApiDbContext dbContext)
        {
                this.dbContext=dbContext;

        }

        public EmployeApiDbContext DbContext { get; }

        [HttpGet]
        public async Task<IActionResult> GetEmployee()
        {
            return Ok(await dbContext.Employee.ToListAsync());
        
        }
        
        
        
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetEmployeeByid([FromRoute]Guid id)
        {
            var Emp = await dbContext.Employee.FindAsync(id);
            if (Emp == null)
            {
                return NotFound();
            }
                return Ok(Emp);

        }


        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployeeRequest addEmployeeRequest)
        {
            var emp = new Employee()
            {
                id = Guid.NewGuid(),
                firstName = addEmployeeRequest.firstName,
                lastName = addEmployeeRequest.lastName,
                email = addEmployeeRequest.email,
                mobile=addEmployeeRequest.mobile,
                age=addEmployeeRequest.age, 
               address=addEmployeeRequest.address
              };
            await dbContext.Employee.AddAsync(emp);
            await dbContext.SaveChangesAsync();

            return Ok(emp);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute]Guid id,UpdateEmployeeRequest updateEmployeeRequest)
        {
            var upEmp = await dbContext.Employee.FindAsync(id);
            if(upEmp!=null)
            {

                upEmp.firstName = updateEmployeeRequest.firstName;
                upEmp.lastName = updateEmployeeRequest.lastName;
                upEmp.email = updateEmployeeRequest.email;
                upEmp.mobile = updateEmployeeRequest.mobile;
                upEmp.age = updateEmployeeRequest.age;
                upEmp.address = updateEmployeeRequest.address;
                await dbContext.SaveChangesAsync();
                    return Ok(upEmp);
            }
            return NotFound();

        }



        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute]Guid id) {

            var Emp1 = await dbContext.Employee.FindAsync(id);
            if(Emp1!=null)
            {
                dbContext.Remove(Emp1);
                await dbContext.SaveChangesAsync(); 
                return Ok(Emp1);
            }
            return NotFound();
     
        }




    }
}
