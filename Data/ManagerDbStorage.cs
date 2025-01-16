using Club.Data;
using Club.Models;
using Microsoft.EntityFrameworkCore;

namespace Club.Data
{
    public class ManagerDbStorage
    {
        private readonly ApplicationDbContext _context;

        public ManagerDbStorage(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Manager>> GetAll()
        {
            return await _context.Managers.ToListAsync();
        }

        public async Task<Manager?> GetById(int id)
        {
            return await _context.Managers.FindAsync(id);
        }

        public async Task Add(Manager manager)
        {
            _context.Managers.Add(manager);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Manager manager)
        {
            _context.Managers.Update(manager);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var manager = await _context.Managers.FindAsync(id);
            if (manager != null)
            {
                _context.Managers.Remove(manager);
                await _context.SaveChangesAsync();
            }
        }
    }
}
