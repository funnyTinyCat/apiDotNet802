using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using api.Dtos.Location;
using api.Dtos.Message;
using api.Dtos.User;
using api.Interfaces;
using api.Mappers;
using api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace api.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {

        private readonly IUserRepository _userRepo;
        private readonly IGenderRepository _genderRepo;
        private readonly ILocationRepository _locationRepo;

        public LoginController(IUserRepository userRepo, IGenderRepository genderRepo, ILocationRepository locationRepo)
        {

            this._userRepo = userRepo;
            this._genderRepo = genderRepo;
            this._locationRepo = locationRepo;
        }

        
       [HttpGet]
       public  IActionResult GetAll() {

            return Ok("Stvarno radi.");
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] GetUserUnPwDto userDto) {

            MessageOneDto message1 = new MessageOneDto();

            if(userDto.Username.IsNullOrEmpty()) {

                message1.Message = "Username is empty.";
                return BadRequest(JsonSerializer.Serialize(message1));
                
            } else if (userDto.Password.IsNullOrEmpty()) {

                message1.Message = "Password is empty.";
                return BadRequest(JsonSerializer.Serialize(message1));
            }

            var user = await _userRepo.GetByUsernameAndPasswordAsync(userDto.Username, userDto.Password);

            if (user == null) {
                
                message1.Message = "User not found.";
                return NotFound(JsonSerializer.Serialize(message1));
            }

            var gender = await _genderRepo.GetByIdAsync((int)user.GenderId);

            if (gender == null) {

                return NotFound("Gender not found.");
            }

            var location = await _locationRepo.GetById((int)user.LocationId);

            if (location == null) {

                return NotFound("Location not found.");
            }

            LocationInsideDto locationDto = new LocationInsideDto();

            locationDto.Lat = location.Lat;
            locationDto.Lng = location.Lng;
            locationDto.Name = location.Name;

            var returnUser = user.ToUserFromReturnUserDto(gender.Name, locationDto);

            MessageDto message = new MessageDto();

            message.Message = "Success!";
            message.Data = returnUser;

            

            return Ok(JsonSerializer.Serialize(message));
        }
    }
}