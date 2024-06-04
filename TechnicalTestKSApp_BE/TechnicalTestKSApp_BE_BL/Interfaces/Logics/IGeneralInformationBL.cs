using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTestKSApp_BE_BL.Interfaces.Logics
{
    public interface IGeneralInformationBL
    {
        Task<IResponse> GetNationalities();
        Task<IResponse> GetBirthDates();
    }
}
