using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RS1.Ispit.Web.EF;
using RS1.Ispit.Web.Models;
using RS1_Faktura.ViewModels;

namespace RS1_Faktura.Controllers
{
    public class FakturaStavkaController : Controller
    {
        MojContext db = new MojContext();
        public IActionResult Index(int FakturaID)
        {
            StavkeFakturePrikaz m = new StavkeFakturePrikaz();
               m.rows = db.FakturaStavka.Where(fs=> fs.FakturaId== FakturaID)
                .Select(fs => new StavkeFakturePrikaz.Rows
                {
                    StavkaID =fs.Id,
                    Proizvod = fs.Proizvod.Naziv,
                    Cijena = fs.Proizvod.Cijena,
                    Kolicina = fs.Kolicina,
                    Popust = fs.PopustProcenat,
                    Iznos = fs.Kolicina * fs.Proizvod.Cijena * (1 - fs.PopustProcenat / 100)
                }).ToList();
            m.FakturaID = FakturaID;
            return View(m);
        }

        public string Obrisi(int StavkeFaktureId)
        {
            FakturaStavka fakturaStavka = db.FakturaStavka.Find(StavkeFaktureId);
            db.Remove(fakturaStavka);
            db.SaveChanges();

            return "OK";
        }
    }
}
