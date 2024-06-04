using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestKSApp_BE_BL.Models;

namespace TechnicalTestKSApp_BE_BL.Interfaces.Repositories
{
    public interface IBeneficiaryRepository
    {
        Task<int> Delete(int id);
        Task<IEnumerable<Beneficiary>> Get(int id);
        Task<IEnumerable<Beneficiary>> GetAll(int employeeId);
        Task<Beneficiary> Insert(Beneficiary Beneficiary);
        Task<Beneficiary> Update(Beneficiary Beneficiary);
    }
}
