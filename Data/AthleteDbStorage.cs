using Club.Data;
using Club.Models;
using Microsoft.EntityFrameworkCore;

namespace Club.Data
{
    public class AthleteDbStorage
    {
        private readonly ApplicationDbContext _context;

        public AthleteDbStorage(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Athlete>> GetAll()
        {
            return await _context.Athletes.ToListAsync();
        }

        public async Task<Athlete?> GetById(int id)
        {
            return await _context.Athletes.FindAsync(id);
        }

        public async Task Add(Athlete athlete)
        {
            _context.Athletes.Add(athlete);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Athlete athlete)
        {
            _context.Athletes.Update(athlete);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var athlete = await _context.Athletes.FindAsync(id);
            if (athlete != null)
            {
                _context.Athletes.Remove(athlete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
