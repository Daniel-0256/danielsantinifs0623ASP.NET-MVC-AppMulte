using AppMulte.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace AppMulte.Controllers
{
    public class AnagraficaController : Controller
    {
        private readonly AppMulteContext _db;

        public AnagraficaController(AppMulteContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var anagrafica = _db.Anagrafica.ToList();
            return View(anagrafica);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Anagrafica anagrafica)
        {
            if (ModelState.IsValid)
            {
                _db.Anagrafica.Add(anagrafica);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(anagrafica);
        }

        public IActionResult Edit(int id)
        {
            Anagrafica anagrafica = _db.Anagrafica.Find(id);
            if (anagrafica == null)
            {
                return NotFound();
            }
            return View(anagrafica);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Anagrafica anagrafica)
        {
            if (ModelState.IsValid)
            {
                var existingAnagrafica = _db.Anagrafica.Find(anagrafica.IDAnagrafica);

                if (existingAnagrafica != null)
                {
                    existingAnagrafica.Cognome = anagrafica.Cognome;
                    existingAnagrafica.Nome = anagrafica.Nome;
                    existingAnagrafica.Indirizzo = anagrafica.Indirizzo;
                    existingAnagrafica.Citta = anagrafica.Citta;
                    existingAnagrafica.CAP = anagrafica.CAP;
                    existingAnagrafica.Cod_Fisc = anagrafica.Cod_Fisc;

                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
            return View(anagrafica);
        }


        public IActionResult Details(int id)
        {
            Anagrafica anagrafica = _db.Anagrafica.Find(id);
            if (anagrafica == null)
            {
                return NotFound();
            }
            return View(anagrafica);
        }
    }
}
