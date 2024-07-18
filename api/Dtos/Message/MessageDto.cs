using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;

namespace api.Dtos.Message
{
    public class MessageDto
    {
        public string Message { get; set; } = string.Empty;
        public ReturnUserDto? Data { get; set; }
    }
}