
using api.Dtos.Lijek;
using api.Models;

namespace api.Mappers
{
    public static class LijekMapper
    {
        public static LijekDto ToLijekDto(this Lijek lijekModel) {

            return new LijekDto {
                Id = lijekModel.Id,
                Sifra = lijekModel.Sifra,
                ImeLijeka = lijekModel.ImeLijeka,
                OpisLijeka = lijekModel.OpisLijeka,
                Slika = lijekModel.Slika,
                Doziranje = lijekModel.Doziranje,
                SlikaNaziv = lijekModel.SlikaNaziv
            };
        }

        public static ReturnLijekDto  ToLijekFromGet( this Lijek lijekModel) {

            return new ReturnLijekDto {
                Id = lijekModel.Id,
                Sifra = lijekModel.Sifra,
                ImeLijeka = lijekModel.ImeLijeka,
                OpisLijeka = lijekModel.OpisLijeka,
                Doziranje = lijekModel.Doziranje,
                SlikaNaziv = lijekModel.SlikaNaziv      
            };      
        }
        
        public static Lijek ToLijekFromCreate(this CreateLijekDto lijekDto) {

            return new Lijek {
                Sifra = lijekDto.Sifra,
                ImeLijeka = lijekDto.ImeLijeka,
                OpisLijeka = lijekDto.OpisLijeka,
                SlikaNaziv = lijekDto.SlikaNaziv,
                Slika = lijekDto.Slika,
                Doziranje = lijekDto.Doziranje
            };
        }

        public static Lijek ToLijekFromUpdate(this UpdateLijekDto lijekDto) {

            return new Lijek {

                Sifra = lijekDto.Sifra,
                ImeLijeka = lijekDto.ImeLijeka,
                OpisLijeka = lijekDto.OpisLijeka,
                SlikaNaziv = lijekDto.SlikaNaziv,
                Slika = lijekDto.Slika,
                Doziranje = lijekDto.Doziranje
            };
        }

        public static LijekImageNazivDto ReturnLijekImage(this LijekImageDto lijekImage) {

            return new LijekImageNazivDto {
                Naziv = lijekImage.Naziv
            };
        }
    }
}