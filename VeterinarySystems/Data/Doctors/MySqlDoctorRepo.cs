using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinarySystems.Model;

namespace VeterinarySystems.Data.Doctors
{
    public class MySqlDoctorRepo : IDoctorsRepo
  {
        private DoctorContext  _docContext;

        public MySqlDoctorRepo(DoctorContext docContext)
        {
            _docContext = docContext;
        }
        public void CreateDoctor(DoctorDetails doctor)
        {
            if(doctor == null)
            {
                throw new ArgumentNullException(nameof(doctor));
            }

            _docContext.Doctors.Add(doctor);
           
        }

        public void DeleteDoctor(DoctorDetails doctor)
        {
            if(doctor == null)
            {
                throw new ArgumentNullException(nameof(doctor));
            }

            _docContext.Doctors.Remove(doctor);

            // throw new NotImplementedException();
        }

        public IEnumerable<DoctorDetails> GetAllDoctors()
        {
            return _docContext.Doctors.ToList();
           // throw new NotImplementedException();
        }

        public DoctorDetails GetDoctorById(int id)
        {
            return _docContext.Doctors.FirstOrDefault(p => p.UserId == id);
            //throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return (_docContext.SaveChanges() >= 0);
           // throw new NotImplementedException();
        }

        /*
        public async Task<IEnumerable<DoctorDetails>> Search(string specialization)
        {
            //throw new NotImplementedException();
            IQueryable<DoctorDetails> query = _docContext.Doctors;

            if (!string.IsNullOrEmpty(specialization))
            {
                query = query.Where(e => e.SpecializationIn.Contains(specialization));
            }

            return await query.ToListAsync();
        }
        */
        public void UpdateDoctor(DoctorDetails doctor)
        {

           // throw new NotImplementedException();
        }

        public async Task<IEnumerable<DoctorDetails>> SearchSpec(string specialization)
        {
            IQueryable<DoctorDetails> query1 = null;

            if(!string.IsNullOrEmpty(specialization))
            {
                query1 = _docContext.Doctors.Where(spec => spec.SpecializationIn.Contains(specialization));
            }
            return await query1.ToListAsync();
        }
    }
}
