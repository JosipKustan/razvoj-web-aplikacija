using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA_Projekt.Models
{
    public enum TipKreditnaKartica
    {
        MasterCard = 1,
        Diners = 2,
        AmericanExpress = 3,
        Visa = 4,
        Other = 5
    }
    [Serializable]
    public class KreditnaKartica
    {
        public int IDKreditnaKartica { get; set; }
        public TipKreditnaKartica Tip { get; set; }
        public string Broj { get; set; }
        public short IstekMjesec { get; set; }
        public short IstekGodina { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return IDKreditnaKartica.Equals(obj);
        }
        public override int GetHashCode()
        {
            return IDKreditnaKartica.GetHashCode();
        }
    }
}