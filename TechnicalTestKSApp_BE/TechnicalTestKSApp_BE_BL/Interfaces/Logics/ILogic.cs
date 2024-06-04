using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestKSApp_BE_BL.Models;

namespace TechnicalTestKSApp_BE_BL.Interfaces.Logics
{
    public interface ILogic
    {   
        Task<IResponse> Delete(int id);
        Task<IResponse> Get(int id);
        Task<IResponse> Get();
    }
}
