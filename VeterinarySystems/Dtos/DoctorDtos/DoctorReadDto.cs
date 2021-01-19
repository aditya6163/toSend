using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeterinarySystems.Dtos.DoctorDto
{
    public class DoctorReadDto
    {
        public int UserId { get; set; }
        public string Degree { get; set; }

        
        public string SpecializationIn { get; set; }

      
        public int Experience { get; set; }

        
        public string Bio { get; set; }

        
        public long Fees { get; set; }
    }
}
