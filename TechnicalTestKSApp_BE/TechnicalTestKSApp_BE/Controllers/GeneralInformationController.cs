using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnicalTestKSApp_BE_BL.Interfaces.Logics;

namespace TechnicalTestKSApp_BE.Controllers
{
    [Route("api/general-information")]
    [ApiController]
    public class GeneralInformationController : ControllerBase
    {

        private readonly IGeneralInformationBL _logic;
        public GeneralInformationController(IGeneralInformationBL employeeBL)
        {
            _logic = employeeBL;
        }

        [HttpGet("nationalities")]
        public async Task<IActionResult> GetNationalities()
        {
            return Ok(await _logic.GetNationalities());
        }

        [HttpGet("date-select")]
        public async Task<IActionResult> GetBirthDates()
        {
            return Ok(await _logic.GetBirthDates());
        }
    }
}
