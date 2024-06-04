using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTestKSApp_BE_BL.Interfaces
{
    public interface INationality
    {
        int NationalityId { get; set; }
        string NationalityName { get; set; }
    }
}
