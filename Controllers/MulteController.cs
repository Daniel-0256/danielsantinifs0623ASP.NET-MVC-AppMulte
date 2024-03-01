using AppMulte.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace AppMulte.Controllers
{
    public class MulteController : Controller
    {
        private readonly AppMulteContext _db;

        public MulteController(AppMulteContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var viewModel = new MulteViewModel
            {
                Multe = _db.Multe.Include(m => m.Anagrafica).Include(m => m.Verbale).Include(m => m.Violazione).ToList(),
                Anagrafica = _db.Anagrafica.ToList(),
                Verbali = _db.Verbali.ToList(),
                Violazioni = _db.Violazioni.ToList()
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Multa multa)
        {
            if (ModelState.IsValid)
            {
                _db.Multe.Add(multa);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(multa);
        }

        public IActionResult Edit(int id)
        {
            Multa multa = _db.Multe.Find(id);
            if (multa == null)
            {
                return NotFound();
            }
            return View(multa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Multa multa)
        {
            if (ModelState.IsValid)
            {
                var existingMulta = _db.Multe.Find(multa.IDMulta);

                if (existingMulta != null)
                {
                    existingMulta.IDAnagrafica = multa.IDAnagrafica;
                    existingMulta.IDVerbale = multa.IDVerbale;
                    existingMulta.IDViolazione = multa.IDViolazione;

                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
            return View(multa);
        }

        public IActionResult Details(int id)
        {
            Multa multa = _db.Multe.Find(id);
            if (multa == null)
            {
                return NotFound();
            }
            return View(multa);
        }

        public IActionResult Delete(int id)
        {
            Multa multa = _db.Multe.Find(id);
            if (multa == null)
            {
                return NotFound();
            }
            return View(multa);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Multa multa = _db.Multe.Find(id);
            _db.Multe.Remove(multa);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult VerbaliPerTrasgressore()
        {
            var verbaliPerTrasgressore = _db.Multe
                .GroupBy(m => m.Anagrafica)
                .Select(g => new VerbaliPerTrasgressore
                {
                    Trasgressore = g.Key,
                    NumeroVerbali = g.Count()
                })
                .ToList();

            return View(verbaliPerTrasgressore);
        }

        public IActionResult PuntiDecurtatiPerTrasgressore()
        {
            var puntiDecurtatiPerTrasgressore = _db.Multe
                .GroupBy(m => m.Anagrafica)
                .Select(g => new PuntiDecurtatiPerTrasgressore
                {
                    Trasgressore = g.Key,
                    TotalePuntiDecurtati = g.Sum(m => m.Verbale.DecurtamentoPunti)
                })
                .ToList();

            return View(puntiDecurtatiPerTrasgressore);
        }

        public IActionResult ViolazioniSuperioriA10Punti()
        {
            var violazioniSuperioriA10Punti = _db.Multe
                .Where(m => m.Verbale.DecurtamentoPunti > 10)
                .Select(m => new ViolazioniSuperioriA10Punti
                {
                    Importo = m.Verbale.Importo,
                    Nome = m.Anagrafica.Nome,
                    Cognome = m.Anagrafica.Cognome,
                    DataViolazione = m.Verbale.DataViolazione,
                    DecurtamentoPunti = m.Verbale.DecurtamentoPunti
                })
                .ToList();

            return View(violazioniSuperioriA10Punti);
        }

        public IActionResult ViolazioniImportoSuperioreA400()
        {
            var violazioniImportoSuperioreA400 = _db.Multe
                .Where(m => m.Verbale.Importo > 400)
                .Select(m => new ViolazioniImportoSuperioreA400
                {
                    Verbale = m.Verbale
                })
                .ToList();

            return View(violazioniImportoSuperioreA400);
        }


    }
}
