using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Location;
using api.Dtos.User;
using api.Models;

namespace api.Mappers
{
    public static class UserMapper
    {
        
        public static ReturnUserDto ToUserFromReturnUserDto(this User user, string gender, LocationInsideDto location) {

            return new ReturnUserDto {

                Id = user.Id,
                Username = user.Username,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Password = user.Password,
                Mobile = user.Mobile,
                Birthday = user.Birthday,
                VisibleGender = user.VisibleGender,
                Token = user.Token,
                Gender = gender,
                Location = location
            };
        }
    }
}