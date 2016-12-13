using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplikacjaRanczo.Models
{
    public class Wojewodztwo
    {
        [Key]
        public int WojewodztwoID { get; set; }
        public string nazwa { get; set; }

        public virtual ICollection<Miejscowosc> Miejscowoscs { get; set; }

    }
}