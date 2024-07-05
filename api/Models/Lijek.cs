using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace api.Models
{
    public class Lijek
    {
        public int Id { get; set; }
        public string Sifra { get; set; } = string.Empty;
        public string ImeLijeka { get; set; } = string.Empty;
        public string OpisLijeka { get; set; } = string.Empty;
    //    public byte[]? Slika { get; set; }
        public string? SlikaNaziv { get; set; }
//        [NotMapped]
        public byte[]? Slika { get; set; }
        public decimal Doziranje { get; set; }
    }
}