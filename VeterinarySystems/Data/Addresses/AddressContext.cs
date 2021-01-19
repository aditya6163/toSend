using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinarySystems.Model;

namespace VeterinarySystems.Data.Addresses
{
    public class AddressContext : DbContext
    {
        internal static IQueryable<Address> _addrDbContext;
        public AddressContext(DbContextOptions<AddressContext> opt) : base(opt)
        {

        }

       public DbSet<Address> Addresses { get; set; }
    }
}
