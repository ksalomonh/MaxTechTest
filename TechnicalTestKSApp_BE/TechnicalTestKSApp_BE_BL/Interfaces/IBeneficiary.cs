using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTestKSApp_BE_BL.Interfaces
{
    public interface IBeneficiary
    {
        int BeneficiaryId { get; set; }
        int EmployeeId { get; set; }
        int ParticipationPercentage { get; set; }
        bool IsDeleted { get; set; }
    }
}
