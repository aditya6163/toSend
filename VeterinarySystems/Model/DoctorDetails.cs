using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VeterinarySystems.Model
{
    public class DoctorDetails
    {
        // Foreign Key
      // [Key]
        
        [Key]
        public int UserId { get; set; }
       

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
     //   public ICollection<User> Users { get; set; }
      //  public User User { get; set; }
    }
}
