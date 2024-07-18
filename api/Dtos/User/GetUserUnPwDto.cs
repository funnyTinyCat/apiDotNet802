using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.User
{
    public class GetUserUnPwDto
    {
        public String? Username { get; set; }
        public String? Password { get; set; }
    }
}