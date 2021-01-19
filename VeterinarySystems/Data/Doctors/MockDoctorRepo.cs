
/*
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinarySystems.Model;

namespace VeterinarySystems.Data.Doctors
{
    public class MockDoctorRepo : IDoctorsRepo
    {
        private readonly object _docContext;

        public void CreateDoctor(DoctorDetails doctor)
        {
            throw new NotImplementedException();
        }

        public void DeleteDoctor(DoctorDetails doctor)
        {
            throw new NotImplementedException();
        }

        // public object UserId { get; private set; }

        public IEnumerable<DoctorDetails> GetAllDoctors()
        {
            var Doctors = new List<DoctorDetails>()
            {
                new DoctorDetails {UserId=1001,Degree="MD",SpecializationIn="CATS",Experience=2,Bio="Good to work with Animals",Fees=350},
                new DoctorDetails {UserId=2001,Degree="MD",SpecializationIn="Dogs",Experience=3,Bio="Good to work with Animals",Fees=380},
                new DoctorDetails {UserId=3001,Degree="MD",SpecializationIn="Rabbit",Experience=7,Bio="Good to work with Animals",Fees=550},
            };
            return Doctors;
            
        }

        public DoctorDetails GetDoctorById(int id)
        {
            return new DoctorDetails { UserId = 1001, Degree = "MD", SpecializationIn = "CATS", Experience = 2, Bio = "Good to work with Animals", Fees = 350 };
             
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DoctorDetails>> SearchAsync(string specialization)
        {
            throw new NotImplementedException();

            


        }

        public void UpdateDoctor(DoctorDetails doctor)
        {
            throw new NotImplementedException();
        }
    }
}
*/