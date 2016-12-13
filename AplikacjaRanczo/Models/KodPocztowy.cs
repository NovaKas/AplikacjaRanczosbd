using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplikacjaRanczo.Models
{
    public class KodPocztowy
    {
        public int KodPocztowyID { get; set; }

        public string kod { get; set; }
        public int MiejscowoscID { get; set; }

        public virtual Miejscowosc Miejscowosc { get; set; }
        public virtual ICollection<Kontrahent> Kontrahents { get; set; }
        
    }
}