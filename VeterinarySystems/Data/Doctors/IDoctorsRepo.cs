using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinarySystems.Model;

namespace VeterinarySystems.Data.Doctors
{
   public  interface IDoctorsRepo
    {
        bool SaveChanges();
       // Task <IEnumerable<DoctorDetails>> Search(string specialization);
        IEnumerable<DoctorDetails> GetAllDoctors();
        DoctorDetails GetDoctorById(int id);
        void CreateDoctor(DoctorDetails doctor);
        void UpdateDoctor(DoctorDetails doctor);

        void DeleteDoctor(DoctorDetails doctor);

        Task<IEnumerable<DoctorDetails>> SearchSpec(string Specialization);

    }
}
