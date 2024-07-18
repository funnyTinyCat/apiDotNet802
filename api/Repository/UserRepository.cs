using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Dtos.User;

namespace api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;
        public UserRepository(ApplicationDBContext context)
        {
            this._context = context;
        }
        
        public async Task<User?> GetByUsernameAndPasswordAsync(string username, string password)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(s => s.Username == username && s.Password == password);

            if (existingUser == null) {

                return null;
            }

            return existingUser;
        }

        public async  Task<UserForPostDto?> GetUserForPostAsync(int id)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(s => s.Id == id);

            if (existingUser == null) {

                return null;
            }

            UserForPostDto userDto = new UserForPostDto();

            userDto.Username = existingUser.Username;
            userDto.Firstname = existingUser.Firstname;
            userDto.Lastname = existingUser.Lastname;

            return userDto;
        }

        public Task<bool> UserExistsAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}