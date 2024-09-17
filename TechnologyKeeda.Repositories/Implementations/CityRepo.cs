using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnologyKeeda.Entities;
using TechnologyKeeda.Repositories.Interfaces;

namespace TechnologyKeeda.Repositories.Implementations
{
    public class CityRepo : ICityRepo
    {
        private readonly ApplicationDbContext _context;
        public CityRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Delete(City city)
        {
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(City city)
        {
            _context.Cities.Update(city);
           await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<City>> GetAll()
        {
            List<City> cities = new List<City>();

            if (_context != null)
            {
                 cities = await _context.Cities.Include(x => x.State).ThenInclude(y => y.Country).ToListAsync();
            }
            return cities;
        }

        public async Task<City> GetById(int id)
        {
            var city = await _context.Cities.Include(x => x.State).ThenInclude(y => y.Country).FirstOrDefaultAsync(x => x.Id == id);
            return city;
        }

        public async Task Save(City city)
        {
            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();
        }
    }
}
