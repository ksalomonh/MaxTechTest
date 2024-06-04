using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestKSApp_BE_BL.Interfaces;

namespace TechnicalTestKSApp_BE_BL.Models
{
    public class Beneficiary : PersonBase, IPerson, IBeneficiary
    {
        public int BeneficiaryId { get; set; }
        public int EmployeeId { get; set; }
        public int ParticipationPercentage { get; set; }
        public bool IsDeleted { get; set; }
    }
}
