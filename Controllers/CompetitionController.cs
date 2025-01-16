using Club.Data;
using Club.Models;
using Microsoft.AspNetCore.Mvc;

namespace Club.Controllers
{
    public class CompetitionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CompetitionDbStorage _competitionDbStorage;

        public CompetitionController(ApplicationDbContext context, CompetitionDbStorage competitionDbStorage)
        {
            _context = context;
            _competitionDbStorage = competitionDbStorage;
        }

        public async Task<IActionResult> Index()
        {
            var competitions = await _competitionDbStorage.GetAll();
            return View(competitions);
        }

        public IActionResult Create()
        {
            var model = new CompetitionViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompetitionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var competition = new Competition
            {
                Name = model.Name,
                Date = model.Date,
                Price = model.Price,
                AudienceCount = model.AudienceCount,
                Result = model.Result,
                Weather = model.Weather,
                FieldId = model.FieldId
            };

            await _competitionDbStorage.Add(competition);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var competition = await _competitionDbStorage.GetById(id);
            if (competition == null)
            {
                return NotFound();
            }

            var model = new CompetitionViewModel
            {
                CompetitionId = competition.CompetitionId,
                Name = competition.Name,
                Date = competition.Date,
                Price = competition.Price,
                AudienceCount = competition.AudienceCount,
                Result = competition.Result,
                Weather = competition.Weather,
                FieldId = competition.FieldId
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CompetitionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var competition = await _competitionDbStorage.GetById(model.CompetitionId);
            if (competition == null)
            {
                return NotFound();
            }

            competition.Name = model.Name;
            competition.Date = model.Date;
            competition.Price = model.Price;
            competition.AudienceCount = model.AudienceCount;
            competition.Result = model.Result;
            competition.Weather = model.Weather;
            competition.FieldId = model.FieldId;

            await _competitionDbStorage.Update(competition);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _competitionDbStorage.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
