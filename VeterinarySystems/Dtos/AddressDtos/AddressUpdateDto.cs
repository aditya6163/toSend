using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VeterinarySystems.Dtos.AddressDtos
{
    public class AddressUpdateDto // Put Patch Delete
    {
        public int UserId { get; set; }

        [Required]
        public string Line1 { get; set; }

        [Required]
        public string Line2 { get; set; }

        [Required]
        public string Landmark { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public long PinCode { get; set; }
    }
}
