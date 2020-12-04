using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Faktura.ViewModels
{
    public class FakturaDodajVM
    {
        public int KlijentID { get; set; }
        public List<SelectListItem> KlijentStavke { get; set; }
        public DateTime Datum { get; set; }
        public int? PonudaID { get; set; }
        public List<SelectListItem> PonudaStavke { get; set; }


    }
}
