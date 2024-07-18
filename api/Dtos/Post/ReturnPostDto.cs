using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;

namespace api.Dtos.Post
{
    public class ReturnPostDto
    {
        
        public int Id { get; set; }
        public String? Message { get; set; }
        public UserForPostDto Owner { get; set; } = new UserForPostDto();
        public DateTime? Date { get; set; }
        public String? Image { get; set; }
    }
}