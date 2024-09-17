using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnologyKeeda.Entities;
using TechnologyKeeda.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TechnologyKeeda.Repositories.Implementations
{
    public class StateRepo : IStateRepo
    {
        private readonly ApplicationDbContext _context;

        public StateRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(State state)
        {
            _context.States.Remove(state);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(State state)
        {
            _context.States.Update(state);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<State>> GetAll()
        {
            var states = await _context.States.Include(x => x.Country).ToListAsync();
            return states;
        }

        public async Task<State> GetById(int id)
        {
            var state = await _context.States.Include(x => x.Country).SingleOrDefaultAsync(s => s.Id == id);
            return state;
        }

        public async Task Save(State state)
        {
           await _context.States.AddAsync(state);
            await _context.SaveChangesAsync();
        }
    }
}
