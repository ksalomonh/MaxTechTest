using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestKSApp_BE_BL.Interfaces;

namespace TechnicalTestKSApp_BE_BL.Models
{
    public class DateSelect : IDateSelect
    {
        public IEnumerable<string> Years { get; set; }
        public IEnumerable<string> Months { get; set; }
        public IEnumerable<string> Days { get; set; }
    }
}
