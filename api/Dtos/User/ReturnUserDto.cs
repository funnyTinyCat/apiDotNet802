using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Location;
using api.Models;

namespace api.Dtos.User
{
    public class ReturnUserDto
    {
        public int Id { get; set; }
        public String Username { get; set; } = string.Empty;
        public String Firstname { get; set; } = string.Empty;
        public String Lastname { get; set; } = string.Empty;
        public String Password { get; set; } = string.Empty;
        public String? Mobile { get; set; }
        public DateOnly? Birthday { get; set; }
        public Boolean? VisibleGender { get; set; }
        public String Token { get; set; } = string.Empty;
        public string? Gender { get; set; }
        public LocationInsideDto? Location { get; set; }
    }
}