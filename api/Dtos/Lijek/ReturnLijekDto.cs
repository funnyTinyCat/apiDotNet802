using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Lijek
{
    public class ReturnLijekDto
    {
        public int Id { get; set; }
        public string Sifra { get; set; } = string.Empty;
        public string ImeLijeka { get; set; } = string.Empty;
        public string OpisLijeka { get; set; } = string.Empty;
//        public byte[]? Slika { get; set; }
        public decimal Doziranje { get; set; }
  //      [NotMapped]
//        public IFormFile? SlikaUpload { get; set; }
        public string? SlikaNaziv {get; set;}   
    }
}