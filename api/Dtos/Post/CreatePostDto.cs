using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Post
{
    public class CreatePostDto
    {
        public String? Message { get; set; }
        public int OwnerId { get; set; }
        public DateTime? Date { get; set; }
        public String? Image { get; set; }
    }
}