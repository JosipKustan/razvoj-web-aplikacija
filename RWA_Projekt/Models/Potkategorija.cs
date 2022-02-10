using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RWA_Projekt.Models
{
    public class Potkategorija
    {
        public int IDPotkategorija { get; set; }

        public Kategorija Kategorija { get; set; }
        [Required]
        public string Naziv { get; set; }
        public override string ToString()
        {
            return Naziv;
        }
    }
}