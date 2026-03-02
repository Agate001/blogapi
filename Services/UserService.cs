using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogapi.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace blogapi.Services
{
    public class UserService :DbContext
    {

        private readonly Context _context;
        internal bool AddUser(CreateAccountDTO userToAdd)
        {
            throw new NotImplementedException();
        }
    }
}