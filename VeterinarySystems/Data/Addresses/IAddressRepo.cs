using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinarySystems.Model;

namespace VeterinarySystems.Data
{
    public interface IAddressRepo
    {
        bool SaveChanges();
        IEnumerable<Address> GetAllAddresses();
        Address GetAddressById(int id);

        void CreateAddress(Address addr);

        void UpdateAddress(Address addr);

        void DeleteAddress(Address addr);

        Task<IEnumerable<Address>> SearchAddr(string City);
    }
}
