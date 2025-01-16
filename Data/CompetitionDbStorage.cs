using Club.Data;
using Club.Models;
using Microsoft.EntityFrameworkCore;

namespace Club.Data
{
    public class CompetitionDbStorage
    {
        private readonly ApplicationDbContext _context;

        public CompetitionDbStorage(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Competition>> GetAll()
        {
            return await _context.Competitions.ToListAsync();
        }

        public async Task<Competition?> GetById(int id)
        {
            return await _context.Competitions.FindAsync(id);
        }

        public async Task Add(Competition competition)
        {
            _context.Competitions.Add(competition);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Competition competition)
        {
            _context.Competitions.Update(competition);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var competition = await _context.Competitions.FindAsync(id);
            if (competition != null)
            {
                _context.Competitions.Remove(competition);
                await _context.SaveChangesAsync();
            }
        }
    }
}
