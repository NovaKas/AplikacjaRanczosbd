using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplikacjaRanczo.Models
{
    public class Rasa
    {
        public int RasaID { get; set; }
        [Required]
        [DisplayName("Rasa")]
        public string nazwa { get; set; }

        [DisplayName("Rasa skrot")]
        public string skrot { get; set; }

        public virtual ICollection<Bydlo> Bydloes { get; set; }
    }
}