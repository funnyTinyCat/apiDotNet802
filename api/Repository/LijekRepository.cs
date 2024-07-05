using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Lijek;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace api.Repository
{
    public class LijekRepository : ILijekRepository
    {


        private readonly ApplicationDBContext _context;
        
        public LijekRepository(ApplicationDBContext context) {

            this._context = context;
        }

        public async Task<bool> CheckSifraUniquenessAsync(string sifra, int id, string flag)
        {

            var existingLijek = new Lijek();

            if (flag == "create") {
            
                existingLijek = await _context.Lijekovi.FirstOrDefaultAsync(x => x.Sifra == sifra);
            } else {

                existingLijek = await _context.Lijekovi.FirstOrDefaultAsync(x => x.Sifra == sifra && x.Id != id);
            }

            if(existingLijek == null)
                return false;

            return true;
        }

        public async Task<Lijek> CreateAsync(Lijek lijekModel)
        {
            await _context.Lijekovi.AddAsync(lijekModel);
            await _context.SaveChangesAsync();

            return lijekModel;
        }

        public async Task<Lijek?> DeleteAsync(int id)
        {
            //
            var lijekModel = await _context.Lijekovi.FirstOrDefaultAsync( x => x.Id == id );

            if (lijekModel == null) {

                return null;
            }

            _context.Lijekovi.Remove(lijekModel);
            await _context.SaveChangesAsync();

            return lijekModel;
        }

        public async Task<List<Lijek>> GetAllAsync()
        {
            return await _context.Lijekovi.ToListAsync();
        }

        public async Task<Lijek?> GetByIdAsync(int id)
        {
            return await _context.Lijekovi.FindAsync(id);
        }

        public async Task<Lijek?> UpdateAsync(int id, Lijek lijekModel)
        {
            var existingLijek = await _context.Lijekovi.FirstOrDefaultAsync( x => x.Id == id );

            if (existingLijek == null) {

                return null;
            }

            existingLijek.Sifra = lijekModel.Sifra;
            existingLijek.ImeLijeka = lijekModel.ImeLijeka;
            existingLijek.OpisLijeka = lijekModel.OpisLijeka;
            existingLijek.Doziranje = lijekModel.Doziranje;
            if (!lijekModel.SlikaNaziv.IsNullOrEmpty())
                existingLijek.SlikaNaziv = lijekModel.SlikaNaziv;
            if (!lijekModel.Slika.IsNullOrEmpty())
                existingLijek.Slika = lijekModel.Slika;

            await _context.SaveChangesAsync();

            return existingLijek;
        }

        public async Task<LijekImageDto?> UpdateImageAsync(int id, byte[] byteFile, string newSlikaNaslov)
        {
            
            var existingLijek = await _context.Lijekovi.FirstOrDefaultAsync(x => x.Id == id);

            if (existingLijek == null)
                return null;

            existingLijek.Slika = byteFile;
            existingLijek.SlikaNaziv = newSlikaNaslov;

            await _context.SaveChangesAsync();

            LijekImageDto lijekImageDto = new LijekImageDto();
            lijekImageDto.Naziv = existingLijek.SlikaNaziv;

            return lijekImageDto;
        }
    }
}