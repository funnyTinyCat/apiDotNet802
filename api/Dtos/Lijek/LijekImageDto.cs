using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace api.Dtos.Lijek
{
    public class LijekImageDto
    {
        public string Naziv { get; set; } = string.Empty;
        public IFormFile? SlikaUpload {get; set;}
    }
}