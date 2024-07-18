using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Post
    {
        public int Id { get; set; }
        public String? Message { get; set; }
        public int OwnerId { get; set; }
        public User? Owner { get; set; }
        public DateTime? Date { get; set; }
        public String? Image { get; set; }

    }
}