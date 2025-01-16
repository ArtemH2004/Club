using Club.Data;
using Club.Models;
using Microsoft.EntityFrameworkCore;

namespace Club.Data
{
    public class ClubsDbStorage
    {
        private readonly ApplicationDbContext _context;

        public ClubsDbStorage(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Clubs>> GetAll()
        {
            return await _context.Clubs.ToListAsync();
        }

        public async Task<Clubs?> GetById(int id)
        {
            return await _context.Clubs.FindAsync(id);
        }

        public async Task Add(Clubs clubs)
        {
            _context.Clubs.Add(clubs);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Clubs clubs)
        {
            _context.Clubs.Update(clubs);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var clubs = await _context.Clubs.FindAsync(id);
            if (clubs != null)
            {
                _context.Clubs.Remove(clubs);
                await _context.SaveChangesAsync();
            }
        }
    }
}
