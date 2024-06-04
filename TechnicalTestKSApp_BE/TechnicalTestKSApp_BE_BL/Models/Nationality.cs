using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TechnicalTestKSApp_BE_BL.Interfaces;

namespace TechnicalTestKSApp_BE_BL.Models
{
    public class Nationality : INationality
    {
        [Range(1, 10, ErrorMessage = "Please, provide the nationality.")]
        public int NationalityId { get; set; }
        public string NationalityName { get; set; }
    }
}
