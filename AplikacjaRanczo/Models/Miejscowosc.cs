using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplikacjaRanczo.Models
{
    public class Miejscowosc
    {
        public int MiejscowoscID { get; set; }
        public string nazwa { get; set; }
        public int WojewodztwoID { get; set; }

        public virtual Wojewodztwo Wojewodztwo { get; set; }
        public virtual ICollection<KodPocztowy> KodPocztowies { get; set; }
        

    }
}