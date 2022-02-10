using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA_Projekt.Models
{
    [Serializable]
    public class Racun
    {
        public int IDRacun { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public string BrojRacuna { get; set; }
        public Kupac Kupac { get; set; }
        public Komercijalist Komercijalist { get; set; }
        public KreditnaKartica KreditnaKartica { get; set; }
        public List<Stavka> Stavke { get; set; }
        public string Komentar { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return IDRacun.Equals(obj);
        }
        public override int GetHashCode()
        {
            return IDRacun.GetHashCode();
        }
    }
}