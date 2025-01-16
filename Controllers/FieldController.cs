using Club.Data;
using Club.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Club.Controllers
{
    public class FieldController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly FieldDbStorage _fieldDbStorage;

        public FieldController(ApplicationDbContext context, FieldDbStorage fieldDbStorage)
        {
            _context = context;
            _fieldDbStorage = fieldDbStorage;
        }

        public async Task<IActionResult> Index()
        {
            var fields = await _fieldDbStorage.GetAll();
            return View(fields);
        }

        public IActionResult Create()
        {
            var model = new FieldViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FieldViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var field = new Field
            {
                Name = model.Name,
                Address = model.Address,
                ClubsId = model.ClubsId
            };

            if (model.Photo != null && model.Photo.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.Photo.CopyToAsync(memoryStream);
                    field.Photo = memoryStream.ToArray();
                }
            }

            await _fieldDbStorage.Add(field);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var field = await _fieldDbStorage.GetById(id);
            if (field == null)
            {
                return NotFound();
            }

            var model = new FieldViewModel
            {
                FieldId = field.FieldId,
                Name = field.Name,
                Address = field.Address,
                ClubsId = field.ClubsId
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FieldViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var field = await _fieldDbStorage.GetById(model.FieldId);
            if (field == null)
            {
                return NotFound();
            }

            field.Name = model.Name;
            field.Address = model.Address;
            field.ClubsId = model.ClubsId;


            if (model.Photo != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.Photo.CopyToAsync(memoryStream);
                    field.Photo = memoryStream.ToArray();
                }
            }

            await _fieldDbStorage.Update(field);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _fieldDbStorage.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}