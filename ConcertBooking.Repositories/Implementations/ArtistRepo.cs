using ConcertBooking.Entities;
using ConcertBooking.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertBooking.Repositories.Implementations
{
    public class ArtistRepo : IArtistRepo
    {
        public readonly ApplicationDbContext _context;

        public ArtistRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(Artist artist)
        {
            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Artist artist)
        {
            _context.Artists.Update(artist);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Artist>> GetAll()
        {
            return await _context.Artists.ToListAsync();
        }

        public async Task<Artist> GetById(int id)
        {
            return await _context.Artists.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task Save(Artist artist)
        {
            await _context.Artists.AddAsync(artist);
            await _context.SaveChangesAsync();
        }
    }
}
