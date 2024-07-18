using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.User
{
    public class UserForPostDto
    {
        public String Username { get; set; } = string.Empty;
        public String Firstname { get; set; } = string.Empty;
        public String Lastname { get; set; } = string.Empty;

    }
}