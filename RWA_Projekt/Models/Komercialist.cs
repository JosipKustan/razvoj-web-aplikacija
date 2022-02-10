using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA_Projekt.Models
{
    [Serializable]
    public class Komercijalist
    {
        public int IDKomercijalist { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public bool StalniZaposlenik { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return IDKomercijalist.Equals(obj);
        }
        public override int GetHashCode()
        {
            return IDKomercijalist.GetHashCode();
        }
    }
}