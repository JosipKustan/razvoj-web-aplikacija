using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RWA_Projekt.Models
{
    
    public class Kategorija
    {
        public int IDKategorija { get; set; }
       
        [Required]
        public string Naziv { get; set; }

        public override string ToString()
        {
            return Naziv;
        }
    }
}