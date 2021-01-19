using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinarySystems.Model;

namespace VeterinarySystems.Data.Doctors
{
    public class DoctorContext : DbContext
    {
        internal static IQueryable<DoctorDetails> _docDbContext;
        public DoctorContext(DbContextOptions<DoctorContext> opt) : base(opt)
        {

        }
        public DbSet<DoctorDetails> Doctors { get; set; }



    }
}
