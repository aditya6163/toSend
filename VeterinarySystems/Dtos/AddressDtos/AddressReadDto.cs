using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeterinarySystems.Dtos.AddressDtos
{
    public class AddressReadDto // GetALL GetById
    {
        public int UserId { get; set; }

        public int Id { get; set; }

      
        public string Line1 { get; set; }

        
        public string Line2 { get; set; }

       
        public string Landmark { get; set; }

        public string City { get; set; }

        
        public string State { get; set; }

        
        public long PinCode { get; set; }

    }
}
