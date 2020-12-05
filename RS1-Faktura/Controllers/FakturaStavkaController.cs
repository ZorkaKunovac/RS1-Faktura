using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RS1.Ispit.Web.EF;
using RS1_Faktura.ViewModels;

namespace RS1_Faktura.Controllers
{
    public class FakturaStavkaController : Controller
    {
        MojContext db = new MojContext();
        public IActionResult Index(int FakturaID)
        {
            var m = db.FakturaStavka.Where(fs=> fs.FakturaId== FakturaID)
                .Select(fs => new StavkeFakturePrikaz
                {
                    NazivProizvoda = fs.Proizvod.Naziv,
                    Cijena = fs.Proizvod.Cijena,
                    Kolicina = fs.Kolicina,
                    Procenat = fs.PopustProcenat,
                    Iznos = fs.Kolicina * fs.Proizvod.Cijena * (1 - fs.PopustProcenat / 100)
                }).ToList();
            
            return View(m);
        }
    }
}
