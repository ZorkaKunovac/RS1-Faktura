using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Faktura.ViewModels
{
    public class StavkeFakturePrikaz
    {
        public int StavkeFaktureId { get; set; }
        public string NazivProizvoda { get; set; }
        public float Cijena { get; set; }
        public float Kolicina { get; set; }
        public float Procenat { get; set; }
        public float Iznos { get; set; }

    }
}
