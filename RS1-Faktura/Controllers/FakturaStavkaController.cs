using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IActionResult Dodaj(int FakturaID)
        {
            var m = new StavkeFaktureDodajVM
            {
                Proizvodi = db.Proizvod.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Naziv
                }).ToList()
            };
            m.FakturaID = FakturaID;
            return View(m);
        }

        //public IActionResult Uredi(int StavkaID)
        //{
        //    var m = db.FakturaStavka.Find(StavkaID)
        //        .Select(fs => new StavkeFaktureDodajVM
        //        {
        //            Proizvodi = db.Proizvod.Select(p => new SelectListItem
        //            {
        //                Value = p.Id.ToString(),
        //                Text = p.Naziv + "-" + p.Cijena
        //            }).ToList(),
        //            Kolicina = fs.Kolicina,
        //            StavkaID = StavkaID
        //        });

        //    return View(m);
        //}

        public string Snimi(StavkeFaktureDodajVM s)
        {
            FakturaStavka fakturaStavka = new FakturaStavka
            {
                FakturaId = s.FakturaID,
                ProizvodId = s.Proizvod,
                Kolicina = s.Kolicina,
                PopustProcenat = 5
            };

            //FakturaStavka fakturaStavka = db.FakturaStavka.Find(s.StavkaID);
            //fakturaStavka.ProizvodId = s.Proizvod;
            //fakturaStavka.Kolicina = s.Kolicina;

            db.Add(fakturaStavka);
            db.SaveChanges();
            return "OK";
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
