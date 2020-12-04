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
    public class FakturaController : Controller
    {
        MojContext db = new MojContext();
        public IActionResult Index()
        {
            var m = db.Faktura
                .Select(f => new FakturaPrikazVM
                {
                    FakturaId = f.Id,
                    ImeKlijenta = f.Klijent.ImePrezime,
                    Datum = f.Datum
                }).ToList();
            return View(m);
        }
        public IActionResult Dodaj()
        {
            var m = new FakturaDodajVM
            {
                KlijentStavke = db.Klijent
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.ImePrezime
                }).ToList(),
                PonudaStavke = db.Ponuda.Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text=s.Klijent.ImePrezime+" - "+ s.Datum.ToString("dd.MM.yyyy")
                }).ToList()

            };

            return View(m);
        }
        public IActionResult Snimi(FakturaDodajVM f)
        {
            Faktura faktura= new Faktura
            {
                Datum = f.Datum,
                KlijentId = f.KlijentID,
            };
            db.Add(faktura);
            if(f.PonudaID!=null)
            {
                Ponuda p = db.Ponuda.Find(f.PonudaID);
                p.Faktura = faktura;
            }
            db.SaveChanges();
            return Redirect("/Faktura/Index");
        }
    }
}