using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RWA_Projekt.Models
{
    [Serializable]
    public class Stavka
    {
        public int IDStavka { get; set; }
        public int RacunID { get; set; }
        public short Kolicina { get; set; }
        public Proizvod Proizvod { get; set; }
        public decimal CijenaPoKomadu { get; set; }
        public decimal PopustUPostocima { get; set; }
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public decimal UkupnaCijena { get; set; }

        public string DisplayCijena { get; set; }
        
    }
}