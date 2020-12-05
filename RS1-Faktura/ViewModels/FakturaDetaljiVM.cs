using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Faktura.ViewModels
{
    public class FakturaDetaljiVM
    {
        public int FakturaId { get; set; }
        public string ImeKlijenta { get; set; }
        public DateTime Datum { get; set; }
    }
}
