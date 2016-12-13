using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplikacjaRanczo.Models
{
    public class Plec
    {
        public int PlecID { get; set; }
        [Required]
        [DisplayName("Płeć")]
        public string nazwa { get; set; }
 
        [DisplayName("Płeć skrót")]
        public string skrot { get; set; }

        public virtual ICollection<Bydlo> Bydloes { get; set; }
    }
}