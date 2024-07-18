using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Post;

namespace api.Dtos.Message
{
    public class MessagePostDto
    {
        public String? Message { get; set; }
        public List<ReturnPostDto>? Data { get; set; }  = new List<ReturnPostDto>();
    }
}