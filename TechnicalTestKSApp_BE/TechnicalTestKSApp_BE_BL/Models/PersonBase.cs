using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestKSApp_BE_BL.Interfaces;
using TechnicalTestKSApp_BE_BL.Models.Validator;

namespace TechnicalTestKSApp_BE_BL.Models
{
    public abstract class PersonBase : Nationality, IPerson
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please, provide the Name field.")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please, provide the Lastname field.")]
        public string LastName { get; set; }

        [
            Required(AllowEmptyStrings = false, ErrorMessage = "Please, provide the Birth Date field.")
            ,IsAdultPerson(ErrorMessage = "Only persons being greater than 18 years can be registered.")
        ]
        public DateTime BirthDate { get; set; } //(Validar que sea mayor de edad)
        public string Curp { get; set; }
        public string Ssn { get; set; }
        [
            Required(AllowEmptyStrings = false, ErrorMessage = "Please, provide the Phone number field.")
            //,MinLength(10,  ErrorMessage = "Please, provide exactly 10 digits for phone number field")
            //,MaxLength(10, ErrorMessage = "Please, provide exactly 10 digits for phone number field")
        ]
        public long Phone { get; set; } //(Validar formato a 10 dígitos)
    }
}
