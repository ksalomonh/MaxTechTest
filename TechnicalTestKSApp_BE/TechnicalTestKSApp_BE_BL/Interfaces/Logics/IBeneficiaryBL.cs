using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestKSApp_BE_BL.Models;

namespace TechnicalTestKSApp_BE_BL.Interfaces.Logics
{
    public interface IBeneficiaryBL : ILogic
    {
        Task<IResponse> GetAll(int employeeId);
        Task<IResponse> Insert(List<Beneficiary> beneficiaries);
        Task<IResponse> Insert(Beneficiary entity);
        Task<IResponse> Update(Beneficiary entity);
    }
}
