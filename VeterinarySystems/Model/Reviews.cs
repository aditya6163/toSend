using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VeterinarySystems.Model
{
    public class Reviews
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public int StarRatings { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Feedback { get; set; }

        [Required]
        public int WrittenBy { get; set; }

        [Required]
        public int WrittenFor { get; set; }
    }
}
