using Club.Data;
using Club.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace Club.Controllers
{
    public class AthleteController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly AthleteDbStorage _athleteDbStorage;

        public AthleteController(ApplicationDbContext context, AthleteDbStorage athleteDbStorage)
        {
            _context = context;
            _athleteDbStorage = athleteDbStorage;
        }

        public async Task<IActionResult> Index()
        {
            var athletes = await _athleteDbStorage.GetAll();
            return View(athletes);
        }

        public IActionResult Create()
        {
            var model = new AthleteViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AthleteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var athlete = new Athlete
            {
                LastName = model.LastName,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                Gender = model.Gender,
                BirthDate = model.BirthDate,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                Height = model.Height,
                Width = model.Width,
                ClubsId = model.ClubsId
            };

            if (model.Photo != null && model.Photo.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.Photo.CopyToAsync(memoryStream);
                    athlete.Photo = memoryStream.ToArray();
                }
            }

            await _athleteDbStorage.Add(athlete);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var athlete = await _athleteDbStorage.GetById(id);
            if (athlete == null)
            {
                return NotFound();
            }

            var model = new AthleteViewModel
            {
                AthleteId = athlete.AthleteId,
                LastName = athlete.LastName,
                FirstName = athlete.FirstName,
                MiddleName = athlete.MiddleName,
                Gender = athlete.Gender,
                BirthDate = athlete.BirthDate,
                PhoneNumber = athlete.PhoneNumber,
                Address = athlete.Address,
                Height = athlete.Height,
                Width = athlete.Width,
                ClubsId = athlete.ClubsId
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AthleteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var athlete = await _athleteDbStorage.GetById(model.AthleteId);
            if (athlete == null)
            {
                return NotFound();
            }

            athlete.LastName = model.LastName;
            athlete.FirstName = model.FirstName;
            athlete.MiddleName = model.MiddleName;
            athlete.Gender = model.Gender;
            athlete.BirthDate = model.BirthDate;
            athlete.PhoneNumber = model.PhoneNumber;
            athlete.Address = model.Address;
            athlete.Height = model.Height;
            athlete.Width = model.Width;
            athlete.ClubsId = model.ClubsId;

            if (model.Photo != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.Photo.CopyToAsync(memoryStream);
                    athlete.Photo = memoryStream.ToArray();
                }
            }

            await _athleteDbStorage.Update(athlete);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _athleteDbStorage.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
