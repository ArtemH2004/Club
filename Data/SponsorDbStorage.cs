using Club.Data;
using Club.Models;
using Microsoft.EntityFrameworkCore;

namespace Club.Data
{
    public class SponsorDbStorage
    {
        private readonly ApplicationDbContext _context;

        public SponsorDbStorage(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Sponsor>> GetAll()
        {
            return await _context.Sponsors.ToListAsync();
        }

        public async Task<Sponsor?> GetById(int id)
        {
            return await _context.Sponsors.FindAsync(id);
        }

        public async Task Add(Sponsor sponsor)
        {
            _context.Sponsors.Add(sponsor);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Sponsor sponsor)
        {
            _context.Sponsors.Update(sponsor);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var sponsor = await _context.Sponsors.FindAsync(id);
            if (sponsor != null)
            {
                _context.Sponsors.Remove(sponsor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
