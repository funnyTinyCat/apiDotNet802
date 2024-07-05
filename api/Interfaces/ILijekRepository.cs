using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Lijek;
using api.Models;

namespace api.Interfaces
{
    public interface ILijekRepository
    {
        Task<List<Lijek>> GetAllAsync();
        Task<Lijek?> GetByIdAsync(int id);
        Task<Lijek> CreateAsync(Lijek lijekModel);
        Task<Lijek?> UpdateAsync(int id, Lijek lijekModel);
        Task<Lijek?> DeleteAsync(int id);
        Task<LijekImageDto?> UpdateImageAsync(int id, byte[] byteFile, string slikaNaslov);

        Task<Boolean> CheckSifraUniquenessAsync(string sifra, int id, string flag);
        
    }
}