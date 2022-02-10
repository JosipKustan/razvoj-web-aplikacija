using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RWA_Projekt.Models
{
    [Serializable]
    public class Proizvod
    {
        public int IDProizvod { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public string BrojProizvoda { get; set; }
        public Boja BojaProizvoda { get; set; }
        public int MinimalnaKolicinaNaSkladistu { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public decimal CijenaBezPDV { get; set; }
        public Potkategorija Potkategorija { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return IDProizvod.Equals(obj);
        }
        public override int GetHashCode()
        {
            return IDProizvod.GetHashCode();
        }
        public static Boja DetermineBojaProizvod(string stringtip)
        {
            switch (stringtip)
            {
                case "Bijela":
                    return Boja.Bijela;
                case "Crna":
                    return Boja.Crna;
                case "Crvena":
                    return Boja.Crvena;
                case "Plava":
                    return Boja.Plava;
                case "Siva":
                    return Boja.Siva;
                case "Srebena":
                    return Boja.Srebrna;
                case "Srebrna/Crna":
                    return Boja.SrebrnaCrna;
                case "Šarena":
                    return Boja.Sarena;
                case "Žuta":
                    return Boja.Zuta;
                default:
                    return Boja.NoColor;

            }
        }
        public static string DetermineBojaRepo(Boja boja)
        {
            switch (boja)
            {
                case Boja.NoColor:
                    return null;
                case Boja.SrebrnaCrna:
                    return "Srebrna/Crna";
                default:
                    return boja.ToString();
            }
        }

        public enum Boja
        {
            [Description("Nema Boje")]
            NoColor = 1,
            [Description("Bijela")]
            Bijela = 2,
            [Description("Crna")]
            Crna = 3,
            [Description("Crvena")]
            Crvena = 4,
            [Description("Plava")]
            Plava = 5,
            [Description("Siva")]
            Siva = 6,
            [Description("Srebrna")]
            Srebrna = 7,
            [Description("Srebrno Crna")]
            SrebrnaCrna = 8,
            [Description("Šarena")]
            Sarena = 9,
            [Description("Žuta")]
            Zuta = 10

        }
    }
}