using Club.Data;
using Club.Models;
using Microsoft.AspNetCore.Mvc;

namespace Club.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ManagerDbStorage _managerDbStorage;

        public ManagerController(ApplicationDbContext context, ManagerDbStorage managerDbStorage)
        {
            _context = context;
            _managerDbStorage = managerDbStorage;
        }

        public async Task<IActionResult> Index()
        {
            var managers = await _managerDbStorage.GetAll();
            return View(managers);
        }

        public IActionResult Create()
        {
            var model = new ManagerViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ManagerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var manager = new Manager
            {
                LastName = model.LastName,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                PhoneNumber = model.PhoneNumber,
                Amount = model.Amount,
                ClubsId = model.ClubsId
            };

            await _managerDbStorage.Add(manager);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var manager = await _managerDbStorage.GetById(id);
            if (manager == null)
            {
                return NotFound();
            }

            var model = new ManagerViewModel
            {
                ManagerId = manager.ManagerId,
                LastName = manager.LastName,
                FirstName = manager.FirstName,
                MiddleName = manager.MiddleName,
                PhoneNumber = manager.PhoneNumber,
                Amount = manager.Amount,
                ClubsId = manager.ClubsId
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ManagerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var manager = await _managerDbStorage.GetById(model.ManagerId);
            if (manager == null)
            {
                return NotFound();
            }

            manager.LastName = model.LastName;
            manager.FirstName = model.FirstName;
            manager.MiddleName = model.MiddleName;
            manager.PhoneNumber = model.PhoneNumber;
            manager.Amount = model.Amount;
            manager.ClubsId = model.ClubsId;

            await _managerDbStorage.Update(manager);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _managerDbStorage.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
