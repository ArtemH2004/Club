using Club.Data;
using Club.Models;
using Microsoft.AspNetCore.Mvc;

namespace Club.Controllers
{
    public class SponsorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SponsorDbStorage _sponsorDbStorage;

        public SponsorController(ApplicationDbContext context, SponsorDbStorage sponsorDbStorage)
        {
            _context = context;
            _sponsorDbStorage = sponsorDbStorage;
        }

        public async Task<IActionResult> Index()
        {
            var sponsors = await _sponsorDbStorage.GetAll();
            return View(sponsors);
        }

        public IActionResult Create()
        {
            var model = new SponsorViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SponsorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var sponsor = new Sponsor
            {
                LastName = model.LastName,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                PhoneNumber = model.PhoneNumber,
                Gender = model.Gender,
                Address = model.Address,
                Percent = model.Percent,
                ClubsId = model.ClubsId
            };

            await _sponsorDbStorage.Add(sponsor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var sponsor = await _sponsorDbStorage.GetById(id);
            if (sponsor == null)
            {
                return NotFound();
            }

            var model = new SponsorViewModel
            {
                SponsorId = sponsor.SponsorId,
                LastName = sponsor.LastName,
                FirstName = sponsor.FirstName,
                MiddleName = sponsor.MiddleName,
                PhoneNumber = sponsor.PhoneNumber,
                Gender = sponsor.Gender,
                Address = sponsor.Address,
                Percent = sponsor.Percent,
                ClubsId = sponsor.ClubsId
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SponsorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var sponsor = await _sponsorDbStorage.GetById(model.SponsorId);
            if (sponsor == null)
            {
                return NotFound();
            }

            sponsor.LastName = model.LastName;
            sponsor.FirstName = model.FirstName;
            sponsor.MiddleName = model.MiddleName;
            sponsor.PhoneNumber = model.PhoneNumber;
            sponsor.Gender = model.Gender;
            sponsor.Address = model.Address;
            sponsor.Percent = model.Percent;
            sponsor.ClubsId = model.ClubsId;

            await _sponsorDbStorage.Update(sponsor);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _sponsorDbStorage.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
