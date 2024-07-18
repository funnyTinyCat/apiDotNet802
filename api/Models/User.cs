using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class User
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
        public int? GenderId { get; set; }
        public Gender? Gender { get; set; }
        public int? LocationId { get; set; }
        public Location? Location { get; set; }
    }
}