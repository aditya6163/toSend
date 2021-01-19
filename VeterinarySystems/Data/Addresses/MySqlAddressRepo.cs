using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinarySystems.Model;

namespace VeterinarySystems.Data.Addresses
{
    public class MySqlAddressRepo : IAddressRepo
      {
        private AddressContext _addrContext;

        // private AddressContext _addrContext;

        public MySqlAddressRepo(AddressContext addrContext)
        {
            _addrContext = addrContext;
        }

         public void CreateAddress(Address addr)
             {
     if(addr == null)
     {
         throw new ArgumentNullException(nameof(addr));
     }

     _addrContext.Addresses.Add(addr);

 }

 public void DeleteAddress(Address addr)
 {
     if (addr == null)
     {
         throw new ArgumentNullException(nameof(addr));
     }

     _addrContext.Addresses.Remove(addr);
 }

 public Address GetAddressById(int id)
 {
     return _addrContext.Addresses.FirstOrDefault(p => p.Id == id);

 }

 public IEnumerable<Address> GetAllAddresses()
 {
     return _addrContext.Addresses.ToList();

 }

 public bool SaveChanges()
 {
     return (_addrContext.SaveChanges() >= 0);

     //throw new NotImplementedException();
 }

 public void UpdateAddress(Address addr)
 {
     throw new NotImplementedException();
 }

        public async Task<IEnumerable<Address>> SearchAddr(string City)
        {
            IQueryable<Address> query = null;

            if(!string.IsNullOrEmpty(City))
            {
                query = _addrContext.Addresses.Where(address => address.City.Contains(City));
            }

            return await query.ToListAsync();
        }

   }
}
