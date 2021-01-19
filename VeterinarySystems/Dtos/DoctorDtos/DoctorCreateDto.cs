using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VeterinarySystems.Dtos.DoctorDto
{
    public class DoctorCreateDto
    {
        

        [Required]
        public string Degree { get; set; }

        [Required]
        public string SpecializationIn { get; set; }

        [Required]
        public int Experience { get; set; }

        [Required]
        public string Bio { get; set; }

        [Required]
        public long Fees { get; set; }
    }
}
