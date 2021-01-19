using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeterinarySystems.Dtos
{
    public class UserReadDto
    {
        
        public int UserId { get; set; }

       
        public string FirstName { get; set; }

        
        public string LastName { get; set; }

        
      //  public string Phone { get; set; }  No need to show client

        
        public string Email_Id { get; set; }


        //  public string Password { get; set; } No need to show client


        public string Role { get; set; }

       
     //   public DateTime CreatedOn { get; set; }



    }
}
