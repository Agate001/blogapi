using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using blogapi.Models;
using blogapi.Models.DTO;
using blogapi.Services.Context;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace blogapi.Services;

    public class UserService : ControllerBase
    {

        private readonly DataContext _context;
        
        public UserService(DataContext context)
        {
            _context = context;
        }

        //helper method to check if user exists in our database
        public bool DoesUserExist(string username)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Username == username) != null;
        }

        public bool AddUser(CreateAccountDTO userToAdd)
        {
            bool result = false; 

            if(userToAdd.Username != null && !DoesUserExist(userToAdd.Username))
        {
            UserModel newUser = new UserModel();

            var HashedPassword = HashPassword(userToAdd.Password);

            newUser.Id = userToAdd.Id;
            newUser.Username = userToAdd.Username;

            newUser.Salt = HashedPassword.Salt;
            newUser.Hash = HashedPassword.Hash;

            _context.Add(newUser);

            result = _context.SaveChanges() != 0;
        }
        return result;

            //we are going to need hash helper function help us hash our password
            //we need to set our newUser.Id = UserToAdd.Id
            //Username
            //Salt
            //Hash

            //then we add it to our DataContex
            //Save our chages
            //return a bool to return true or false
        }
    public PasswordDTO HashPassword(string? password)
    {
        PasswordDTO newHashedPassword = new PasswordDTO();

        byte[] SaltBytes = new byte[64];
         
         var provider = RandomNumberGenerator.Create();
         provider.GetNonZeroBytes(SaltBytes);

         var Salt = Convert.ToBase64String(SaltBytes);

         var rfc2898DeriveBytes = new Rfc2898DeriveBytes (password ?? "", SaltBytes, 10000,
          HashAlgorithmName.SHA256);

          var Hash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

          newHashedPassword.Salt = Salt;
          newHashedPassword.Hash = Hash;

          return newHashedPassword;

    }

    //helper to verify password

        public bool verifyUserPassword(string? Password, string? StoredHash, string? StoredSalt)
    {
        if(StoredSalt == null)
        {
            return false;
        }
        var SaltBytes = Convert.FromBase64String(StoredSalt);

        var rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password ?? "", SaltBytes, 10000,
        HashAlgorithmName.SHA256);

        var newHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

        return newHash == StoredHash;

    }

    public IEnumerable<UserModel> GetAllUsers()
    {
        return _context.UserInfo;
    }

    public UserModel GetAlluserDataByUsername(string username)
    {
        return _context .UserInfo.FirstOrDefault(user => user.Username == username);
    }

    public IActionResult Login(LoginDTO user)
    {
            IActionResult result = Unauthorized();
        if (DoesUserExist(user.Username))
        {
             UserModel founduser = GetAlluserDataByUsername(user.Username);
            if (verifyUserPassword(user.Password, founduser.Hash, founduser.Salt))
            {
                
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("evenmoresuperdupersecurekey@3456789"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: "http://localhost:5059/",
                audience: "http://localhost:5059/",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            result = Ok(new{Token = tokenString});
            }
        }
        return result;
    }

    internal UserIdDTO GetUserIdDTOByUserName(string username)
    {
        throw new NotImplementedException();
    }

    //helper function
    public UserModel GetUserByUsername(string username)
    {
        return _context.UserInfo.SingleOrDefault(user => user.Username == username);
    }
    public bool DeleteUser(string userToDelete)
    {
        UserModel foundUser = GetUserByUsername(userToDelete);
        bool result = false;

        if(foundUser != null)
        {
            foundUser.Username = userToDelete;
            _context.Remove(foundUser);

            result = _context.SaveChanges() != 0;
        }
        return result;
    }
    public UserModel GetuserById(int id)
    {
        return _context.UserInfo.SingleOrDefault(user => user.Id == id);
    }

    internal bool UpdateUser(int id, string username)
    {
        UserModel foundUser = GetuserById(id);
        bool result = false;
        if(foundUser != null)
        {
            foundUser.Username = username;
            _context.Update(foundUser);
            result = _context.SaveChanges() != 0;
        }
        return result;
    }
}
