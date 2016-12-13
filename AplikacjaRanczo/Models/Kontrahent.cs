using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplikacjaRanczo.Models
{
    public class Kontrahent
    {
        [Key]
        public int KontrahentID { get; set; }
        [Required]
        public string nazwa { get; set; }
        [Required]
        [StringLength(10)]
        public string nip { get; set; }
        [Required]
        [DisplayName("Kod pocztowy")]
        [RegularExpression(@"[0-9]{2}\-[0-9]{3}")]
        public int KodPocztowyID { get; set; }
        [Required]
        [DisplayName("Ulica")]
        public string ulica { get; set; }
        [Required]
        [DisplayName("Nr domu")]
        public string nr_domu { get; set; }

        public virtual KodPocztowy KodPocztowy { get; set; }
        public virtual ICollection<Samochod> Samochods { get; set; }
        public virtual ICollection<KsiegaSprzedazy> KsiegaSprzedazies { get; set; }


    }
}