using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AplikacjaRanczo.Models
{
    public class Bydlo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BydloID { get; set; }
        [Required]
        [StringLength(9)]
        [DisplayName("Nr ARIMR")]
        public string id_armir { get; set; }
        [Required]
        [DisplayName("Nr paszportu")]
        public string nr_paszportu { get; set; }
        [DisplayName("Matka")]
        public int? MatkaID { get; set; }
        [Required]
        [DisplayName("Rasa")]
        public int RasaID { get; set; }
        [Required]
        [DisplayName("Plec")]
        public int PlecID { get; set; }

        public virtual Rasa Rasa { get; set; }
        public virtual Plec Plec { get; set; }
        public virtual ICollection<KsiegaSprzedazy> KsiegaSprzedazies { get; set; }

        
        [ForeignKey("MatkaID")]
        public virtual Bydlo Matka { get; set; }

    }
}