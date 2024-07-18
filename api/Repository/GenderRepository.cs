using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class GenderRepository : IGenderRepository
    {
        private readonly ApplicationDBContext _context;
        public GenderRepository(ApplicationDBContext context)
        {
            this._context = context;
        }

        public async Task<Gender?> GetByIdAsync(int id)
        {
            var gender = await _context.Genders.FirstOrDefaultAsync(s => s.Id == id);

            if (gender == null) {

                return null;
            }

            return gender;
        }
    }
}