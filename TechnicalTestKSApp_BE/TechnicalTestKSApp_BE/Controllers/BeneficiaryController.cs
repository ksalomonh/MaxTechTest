using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnicalTestKSApp_BE_BL.Interfaces.Logics;
using TechnicalTestKSApp_BE_BL.Logics;
using TechnicalTestKSApp_BE_BL.Models;

namespace TechnicalTestKSApp_BE.Controllers
{
    [Route("api/beneficiaries")]
    [ApiController]
    public class BeneficiaryController : ControllerBase
    {
        private readonly IBeneficiaryBL _logic;
        public BeneficiaryController(IBeneficiaryBL beneficiaryBL)
        {
            _logic = beneficiaryBL;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Insert([FromBody] List<Beneficiary> beneficiaries)
        {
            return Ok(await _logic.Insert(beneficiaries));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] Beneficiary beneficiary)
        {
            return Ok(await _logic.Update(beneficiary));
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

        [HttpGet("get-all/{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            return Ok(await _logic.GetAll(id));
        }
    }
}
