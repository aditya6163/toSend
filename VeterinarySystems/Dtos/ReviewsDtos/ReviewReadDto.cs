using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeterinarySystems.Dtos.ReviewsDtos
{
    public class ReviewReadDto
    {
        
       public int ReviewId { get; set; }

       
        public int StarRatings { get; set; }

        
        public string Feedback { get; set; }

        
        public int WrittenBy { get; set; }

       
        public int WrittenFor { get; set; }



    }
}
