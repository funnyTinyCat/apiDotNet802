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
    public class LocationRepository : ILocationRepository
    {
      private readonly ApplicationDBContext _context;
        public LocationRepository(ApplicationDBContext context)
        {
            this._context = context;
        }
        public async Task<Location?> GetById(int id)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(s => s.Id == id);

            if (location == null) {

                return null;
            }

            return location;
        }
    }
}