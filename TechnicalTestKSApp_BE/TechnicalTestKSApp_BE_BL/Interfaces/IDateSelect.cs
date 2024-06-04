using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTestKSApp_BE_BL.Interfaces
{
    public interface IDateSelect
    {
        IEnumerable<string> Years { get; set; }
        IEnumerable<string> Months { get; set; }
        IEnumerable<string> Days { get; set; }
    }
}
