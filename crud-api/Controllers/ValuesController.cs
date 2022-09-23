using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Task_DAL.IntalioDbModel;
namespace crud_api.Controllers
{
    [Route("api/crud")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("GetAllEmployees")]
        public Object GetAllEmployees()
        {
            var dbClass = new Task_DAL.dbClass();
            var data = dbClass.getAllEmployees();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
        [HttpDelete("DeleteEmployee")]
        public bool DeleteEmployee(int id)
        {
            try
            {
                var dbClass = new Task_DAL.dbClass();
                dbClass.deleteEmployeeById(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPut("UpdateEmployee")]
        public bool UpdateEmployee(TblEmployee Employee)
        {
            try
            {
                var dbClass = new Task_DAL.dbClass();
                dbClass.updateEmployee(Employee);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPost("AddEmployee")]
        public async Task<Object> AddEmployee([FromBody] TblEmployee Employee)
        {
            try
            {
                var dbClass = new Task_DAL.dbClass();
                await dbClass.addEmployees(Employee);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
