using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VeterinarySystems.Dtos.UserDto
{
    public class UserUpdateDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(12)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email_Id { get; set; }

        [Required]
        [MaxLength(45)]
        public string Password { get; set; }

        [Required]
        [MaxLength(25)]
        public string Role { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
    }
}
