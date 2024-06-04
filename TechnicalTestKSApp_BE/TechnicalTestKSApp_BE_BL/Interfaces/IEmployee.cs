using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTestKSApp_BE_BL.Interfaces
{
    public interface IEmployee
    {
        int EmployeeId { get; set; }
        string EmployeeNumber { get; set; }
        public int BeneficiariesCount { get; set; }
    }
}
