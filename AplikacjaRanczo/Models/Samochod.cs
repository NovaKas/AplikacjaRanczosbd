﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplikacjaRanczo.Models
{
    public class Samochod
    {
        [Key]
        public int SamochodID { get; set; }
        [DisplayName("nr rejestracyjny")]
        public string nr_rejestracyjny { get; set; }
        [DisplayName("marka")]
        public int MarkaID { get; set; }
        public string model { get; set; }

        
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        public DateTime rocznik { get; set; }
        [DisplayName("kraj")]
        public int KrajID { get; set; }

        public virtual Kraj Kraj { get; set; }
        public virtual Marka Marka { get; set; }
        public virtual ICollection<Kontrahent> Kontrahents { get; set; }


    }
}