using Club.Data;
using Club.Models;
using Microsoft.EntityFrameworkCore;

namespace Formula.Data
{
    public class FieldDbStorage
    {
        private readonly ApplicationDbContext _context;

        public FieldDbStorage(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Field>> GetAll()
        {
            return await _context.Fields.ToListAsync();
        }

        public async Task<Field?> GetById(int id)
        {
            return await _context.Fields.FindAsync(id);
        }

        public async Task Add(Field field)
        {
            _context.Fields.Add(field);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Field field)
        {
            _context.Fields.Update(field);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var field = await _context.Fields.FindAsync(id);
            if (field != null)
            {
                _context.Fields.Remove(field);
                await _context.SaveChangesAsync();
            }
        }
    }
}
