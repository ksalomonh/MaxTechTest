using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestKSApp_BE_BL.Interfaces;
using TechnicalTestKSApp_BE_BL.Interfaces.Logics;
using TechnicalTestKSApp_BE_BL.Interfaces.Repositories;
using TechnicalTestKSApp_BE_BL.Models;

namespace TechnicalTestKSApp_BE_BL.Logics
{
    public class GeneralInformationBL : IGeneralInformationBL
    {
        private readonly IResponse _response;

        private readonly IGeneralInformationRepository _generalInfoRepository;
        public GeneralInformationBL(IResponse response, IGeneralInformationRepository generalInfoRepository)
        {
            _response = response;
            _generalInfoRepository = generalInfoRepository;
        }

        public async Task<IResponse> GetNationalities()
        {
            _response.Response = await _generalInfoRepository.GetNationalities();
            return await Task.FromResult(_response);
        }

        public async Task<IResponse> GetBirthDates()
        {
            IDateSelect select = new DateSelect()
            {
                Years = Enumerable.Range(1950, DateTime.Now.Year - 1950 + 1).Select(y => y.ToString()),
                Months = Enumerable.Range(1, 12).Select(m => m.ToString("D2")),
                Days = Enumerable.Range(1, 31).Select(d => d.ToString("D2"))
            };

            _response.Response = select;
            return await Task.FromResult(_response);
        }
    }
}
