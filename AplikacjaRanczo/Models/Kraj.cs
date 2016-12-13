using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplikacjaRanczo.Models
{
    public class Kraj
    {
        public int KrajID { get; set; }
        [Required]
        [DisplayName("Nazwa kraju")]
        public string nazwa { get; set; }

        public virtual ICollection<Samochod> Samochods { get; set; }
    }
}