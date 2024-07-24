using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Dtos.User;

namespace api.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAndPasswordAsync(string username, string password);

        Task<UserForPostDto?> GetUserForPostAsync(int? id);
        Task<Boolean> UserExistsAsync(int? id);
        Task<User?> GetByIdAsync(int? id);
    }
}