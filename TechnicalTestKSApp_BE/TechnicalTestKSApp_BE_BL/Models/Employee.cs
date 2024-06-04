using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestKSApp_BE_BL.Interfaces;

namespace TechnicalTestKSApp_BE_BL.Models
{
    public class Employee : PersonBase, IPerson, IEmployee
    {
        public int EmployeeId { get; set; }
        public string EmployeeNumber { get; set; }
        public int BeneficiariesCount { get; set; }
    }
}
