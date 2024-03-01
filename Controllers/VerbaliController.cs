using AppMulte.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace AppMulte.Controllers
{
    public class VerbaliController : Controller
    {
        private readonly AppMulteContext _db;

        public VerbaliController(AppMulteContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var verbali = _db.Verbali.ToList();
            return View(verbali);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Verbale verbale)
        {
            if (ModelState.IsValid)
            {
                _db.Verbali.Add(verbale);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(verbale);
        }

        public IActionResult Edit(int id)
        {
            Verbale verbale = _db.Verbali.Find(id);
            if (verbale == null)
            {
                return NotFound();
            }
            return View(verbale);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Verbale verbale)
        {
            if (ModelState.IsValid)
            {
                var existingVerbale = _db.Verbali.Find(verbale.IDVerbale);

                if (existingVerbale != null)
                {
                    existingVerbale.DataViolazione = verbale.DataViolazione;
                    existingVerbale.IndirizzoViolazione = verbale.IndirizzoViolazione;
                    existingVerbale.IDAgente = verbale.IDAgente;
                    existingVerbale.DataTrascrizioneVerbale = verbale.DataTrascrizioneVerbale;
                    existingVerbale.Importo = verbale.Importo;
                    existingVerbale.DecurtamentoPunti = verbale.DecurtamentoPunti;

                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
            return View(verbale);
        }

        public IActionResult Details(int id)
        {
            Verbale verbale = _db.Verbali.Find(id);
            if (verbale == null)
            {
                return NotFound();
            }
            return View(verbale);
        }
    }
}
