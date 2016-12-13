using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AplikacjaRanczo.Models
{
    public class Marka
    {
        public int MarkaID { get; set; }
        [DisplayName("Nazwa marki")]
        public string nazwa { get; set; }

        public virtual ICollection<Samochod> Samochods { get; set; }
    }
}