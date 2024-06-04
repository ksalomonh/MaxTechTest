using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestKSApp_BE_BL.Models;

namespace TechnicalTestKSApp_BE_BL.Interfaces.Logics
{
    public interface IEmployeeBL : ILogic
    {
        Task<IResponse> Insert(Employee entity);
        Task<IResponse> Update(Employee entity);
    }
}
