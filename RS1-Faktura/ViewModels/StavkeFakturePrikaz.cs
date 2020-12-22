using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Faktura.ViewModels
{
    public class StavkeFakturePrikaz
    {
        public class Rows
        {
            public int StavkaID { get; set; }
            public string Proizvod { get; set; }
            public float Cijena { get; set; }
            public float Kolicina { get; set; }
            public float Popust { get; set; }
            public float Iznos { get; set; }
        }
        public int FakturaID { get; set; }
        public List<Rows> rows { get; set; }
    }
}
