using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogapi.Models.DTO;
using blogapi.Services.Context;
using Microsoft.EntityFrameworkCore;

namespace blogapi.Services
{
    public class UserService
    {

        private readonly DataContext _context;
        
        public UserService(DataContext context)
        {
            _context = context;
        }


        internal bool AddUser(CreateAccountDTO userToAdd)
        {
            throw new NotImplementedException();
        }
    }
}