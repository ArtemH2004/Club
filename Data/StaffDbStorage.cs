using Club.Data;
using Club.Models;
using Microsoft.EntityFrameworkCore;

namespace Formula.Data
{
    public class StaffDbStorage
    {
        private readonly ApplicationDbContext _context;

        public StaffDbStorage(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Staff>> GetAll()
        {
            return await _context.Staffs.ToListAsync();
        }

        public async Task<Staff?> GetById(int id)
        {
            return await _context.Staffs.FindAsync(id);
        }

        public async Task Add(Staff staff)
        {
            _context.Staffs.Add(staff);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Staff staff)
        {
            _context.Staffs.Update(staff);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var staff = await _context.Staffs.FindAsync(id);
            if (staff != null)
            {
                _context.Staffs.Remove(staff);
                await _context.SaveChangesAsync();
            }
        }
    }
}
