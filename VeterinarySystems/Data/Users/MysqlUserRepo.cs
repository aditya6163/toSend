﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinarySystems.Model;

namespace VeterinarySystems.Data.Users
{
    public class MysqlUserRepo : IUserRepo
    {
        private UserContext _context;

        public MysqlUserRepo(UserContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Users.Add(user);
        }

        public void DeleteUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _context.Users.Remove(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
                
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(p => p.UserId == id);
            //throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >=0);
        }

        public void UpdateUser(User user)
        {
            
        }
    }
}
