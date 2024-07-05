using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Lijek
{
    public class UpdateLijekDto
    {
        [Required]
        [MinLength(6, ErrorMessage = "Sifra mora biti najmanje 6 karaktera.")]
        [MaxLength(6, ErrorMessage = "Sifra ne smije biti preko 6 karaktera.")]
        public string Sifra { get; set; } = string.Empty;
        [Required]
        public string ImeLijeka { get; set; } = string.Empty;
        [Required]
        [MinLength(6, ErrorMessage = "OpisLijeka mora biti najmanje 6 karaktera.")]
        [MaxLength(300, ErrorMessage = "OpisLijeka ne smije biti preko 300 karaktera.")]
        public string OpisLijeka { get; set; } = string.Empty;
        public string? SlikaNaziv {get; set; }
        public byte[]? Slika { get; set; }
        [Required]
        public decimal Doziranje { get; set; }
        [NotMapped]
        public IFormFile? SlikaUpload { get; set; }        
    }
}