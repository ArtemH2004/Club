using Club.Data;
using Club.Models;
using Microsoft.AspNetCore.Mvc;

namespace Club.Controllers
{
    public class ClubsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ClubsDbStorage _clubsDbStorage;

        public ClubsController(ApplicationDbContext context, ClubsDbStorage clubsDbStorage)
        {
            _context = context;
            _clubsDbStorage = clubsDbStorage;
        }

        public async Task<IActionResult> Index()
        {
            var clubs = await _clubsDbStorage.GetAll();
            return View(clubs);
        }

        public IActionResult Create()
        {
            var model = new ClubsViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClubsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var club = new Clubs
            {
                Name = model.Name,
                CreatedDeate = model.CreatedDeate,
                Address = model.Address,
                CompetitionId = model.CompetitionId,
                FieldId = model.FieldId,
            };

            if (model.Photo != null && model.Photo.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.Photo.CopyToAsync(memoryStream);
                    club.Photo = memoryStream.ToArray();
                }
            }

            await _clubsDbStorage.Add(club);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var club = await _clubsDbStorage.GetById(id);
            if (club == null)
            {
                return NotFound();
            }

            var model = new ClubsViewModel
            {
                ClubsId = club.ClubsId,
                Name = club.Name,
                CreatedDeate = club.CreatedDeate,
                Address = club.Address,
                CompetitionId = club.CompetitionId,
                FieldId = club.FieldId,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ClubsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var club = await _clubsDbStorage.GetById(model.ClubsId);
            if (club == null)
            {
                return NotFound();
            }

            club.Name = model.Name;
            club.CreatedDeate = model.CreatedDeate;
            club.Address = model.Address;
            club.CompetitionId = model.CompetitionId;
            club.FieldId = model.FieldId;

            if (model.Photo != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.Photo.CopyToAsync(memoryStream);
                    club.Photo = memoryStream.ToArray();
                }
            }

            await _clubsDbStorage.Update(club);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _clubsDbStorage.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
