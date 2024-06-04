using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnicalTestKSApp_BE_BL.Interfaces.Logics;
using TechnicalTestKSApp_BE_BL.Logics;
using TechnicalTestKSApp_BE_BL.Models;

namespace TechnicalTestKSApp_BE.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBL _logic;
        public EmployeeController(IEmployeeBL employeeBL)
        {
            _logic = employeeBL;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Insert([FromBody] Employee employee)
        {
            return Ok(await _logic.Insert(employee));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] Employee employee)
        {
            return Ok(await _logic.Update(employee));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _logic.Delete(id));
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _logic.Get(id));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _logic.Get());
        }
    }
}
