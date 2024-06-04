using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTestKSApp_BE_BL.Interfaces
{
    public interface IPerson
    {
        string Name { get; set; }
        string LastName { get; set; }
        DateTime BirthDate { get; set; } //(Validar que sea mayor de edad)
        string Curp { get; set; }
        string Ssn { get; set; }
        long Phone { get; set; } //(Validar formato a 10 dígitos)
    }
}
