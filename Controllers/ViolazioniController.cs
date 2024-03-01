using AppMulte.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace AppMulte.Controllers
{
    public class ViolazioniController : Controller
    {
        private readonly AppMulteContext _db;

        public ViolazioniController(AppMulteContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var Violazioni = _db.Violazioni.ToList();
            return View(Violazioni);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Violazione violazione)
        {
            if (ModelState.IsValid)
            {
                _db.Violazioni.Add(violazione);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(violazione);
        }

        public IActionResult Edit(int id)
        {
            Violazione violazione = _db.Violazioni.Find(id);
            if (violazione == null)
            {
                return NotFound();
            }
            return View(violazione);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Violazione violazione)
        {
            if (ModelState.IsValid)
            {
                var existingViolazione = _db.Violazioni.Find(violazione.IDViolazione);

                if (existingViolazione != null)
                {
                    existingViolazione.Descrizione = violazione.Descrizione;

                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
            return View(violazione);
        }

        public IActionResult Details(int id)
        {
            Violazione violazione = _db.Violazioni.Find(id);
            if (violazione == null)
            {
                return NotFound();
            }
            return View(violazione);
        }
    }
}
