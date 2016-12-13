using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplikacjaRanczo.Models
{
    public class KsiegaSprzedazy
    {
        [Key]
        [DisplayName("ID")]
        public int KsiegaSprzedazyID { get; set; }
        [Required]
        [DisplayName("Zwierze")]
        public int BydloID { get; set; }
        [Required]
        [DisplayName("Kontrahent")]
        public int KontrahentID { get; set; }
        [Required]
        [DisplayName("Samochod")]
        public int SamochodID { get; set; }
        [Required]
        [DisplayName("Data transakcji")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime data { get; set; }
        [Required]
        [DisplayName("Zakup/Sprzedaż")]
        public bool czyZakup { get; set; } //true - zakup; false - sprzedaz

        public virtual Samochod Samochod { get; set; }
        public virtual Kontrahent Kontrahent { get; set; }
        public virtual Bydlo Bydlo { get; set; }

    }
}