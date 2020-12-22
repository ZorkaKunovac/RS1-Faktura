using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Faktura.ViewModels
{
    public class StavkeFaktureDodajVM
    {
        public int StavkaID { get; set; }
        public int FakturaID { get; set; }
        public int Proizvod { get; set; }
        public List<SelectListItem> Proizvodi { get; set; }
        public float Kolicina { get; set; }
    }
}
