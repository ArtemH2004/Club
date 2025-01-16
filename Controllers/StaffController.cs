using Club.Data;
using Club.Models;
using Microsoft.AspNetCore.Mvc;

namespace Club.Controllers
{
    public class StaffController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly StaffDbStorage _staffDbStorage;

        public StaffController(ApplicationDbContext context, StaffDbStorage staffDbStorage)
        {
            _context = context;
            _staffDbStorage = staffDbStorage;
        }

        public async Task<IActionResult> Index()
        {
            var staffMembers = await _staffDbStorage.GetAll();
            return View(staffMembers);
        }

        public IActionResult Create()
        {
            var model = new StaffViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StaffViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var staff = new Staff
            {
                LastName = model.LastName,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                PhoneNumber = model.PhoneNumber,
                Gender = model.Gender,
                Job = model.Job,
                Amount = model.Amount,
                ClubsId = model.ClubsId
            };

            await _staffDbStorage.Add(staff);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var staff = await _staffDbStorage.GetById(id);
            if (staff == null)
            {
                return NotFound();
            }

            var model = new StaffViewModel
            {
                StaffId = staff.StaffId,
                LastName = staff.LastName,
                FirstName = staff.FirstName,
                MiddleName = staff.MiddleName,
                PhoneNumber = staff.PhoneNumber,
                Gender = staff.Gender,
                Job = staff.Job,
                Amount = staff.Amount,
                ClubsId = staff.ClubsId
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StaffViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var staff = await _staffDbStorage.GetById(model.StaffId);
            if (staff == null)
            {
                return NotFound();
            }

            staff.LastName = model.LastName;
            staff.FirstName = model.FirstName;
            staff.MiddleName = model.MiddleName;
            staff.PhoneNumber = model.PhoneNumber;
            staff.Gender = model.Gender;
            staff.Job = model.Job;
            staff.Amount = model.Amount;
            staff.ClubsId = model.ClubsId;

            await _staffDbStorage.Update(staff);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _staffDbStorage.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
