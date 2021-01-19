using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinarySystems.Model;

namespace VeterinarySystems.Data
{
    public class MockUserRepo : IUserRepo
    {
        public void CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = new List<User>
            {
            new User { UserId = 1001, FirstName = "Anuja", LastName = "Bankar", Phone = "9021098765", Email_Id = "anuja711@gmail.com", Password = "Anuja1234", Role = "Doctor", CreatedOn = new DateTime(2020, 12, 1) },
            new User { UserId = 1002, FirstName = "Sayali", LastName = "Raut", Phone = "9146523165", Email_Id = "sayali711@gmail.com", Password = "sayali1234", Role = "Customer", CreatedOn = new DateTime(2020, 2, 2) },
            new User { UserId = 1003, FirstName = "Pranali", LastName = "Wankhade", Phone = "8654366890", Email_Id = "prana711@gmail.com", Password = "pranalia1234", Role = "Doctor", CreatedOn = new DateTime(2020, 2, 10) },
            new User { UserId = 1004, FirstName = "Aditya", LastName = "Rajpurohit", Phone = "8761546823", Email_Id = "aditya711@gmail.com", Password = "aditya1234", Role = "Customer", CreatedOn = new DateTime(2020, 11, 5) },

        };

            return users;
        }

        public User GetUserById(int id)
        {

            return new User { UserId = 1001, FirstName = "Anuja", LastName = "Bankar", Phone = "9021098765", Email_Id = "anuja711@gmail.com", Password = "Anuja1234", Role = "Customer", CreatedOn = new DateTime(2020, 12, 1) };

        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
