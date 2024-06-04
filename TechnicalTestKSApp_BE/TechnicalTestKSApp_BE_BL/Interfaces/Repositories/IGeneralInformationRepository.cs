using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestKSApp_BE_BL.Models;

namespace TechnicalTestKSApp_BE_BL.Interfaces.Repositories
{
    public interface IGeneralInformationRepository
    {
        Task<IEnumerable<Nationality>> GetNationalities();
    }
}
