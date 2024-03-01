using AppMulte.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;


namespace AppMulte.Controllers
{
    public class AgentiController : Controller
    {
        private readonly AppMulteContext _db;

        public AgentiController(AppMulteContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var agenti = _db.Agenti.ToList();
            return View(agenti);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Agente agente)
        {
            if (ModelState.IsValid)
            {
                _db.Agenti.Add(agente);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(agente);
        }

        public IActionResult Edit(int id)
        {
            Agente agente = _db.Agenti.Find(id);
            if (agente == null)
            {
                return NotFound();
            }
            return View(agente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Agente agente)
        {
            if (ModelState.IsValid)
            {
                var existingAgente = _db.Agenti.Find(agente.IDAgente);

                if (existingAgente != null)
                {
                    existingAgente.NomeAgente = agente.NomeAgente;
                    existingAgente.CognomeAgente = agente.CognomeAgente;

                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
            return View(agente);
        }

        public IActionResult Details(int id)
        {
            Agente agente = _db.Agenti.Find(id);
            if (agente == null)
            {
                return NotFound();
            }
            return View(agente);
        }
    }
}
