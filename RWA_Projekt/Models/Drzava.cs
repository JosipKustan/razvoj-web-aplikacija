using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA_Projekt.Models
{
    public class Drzava
    {
        public int IDDrzava { get; set; }
        public string Naziv { get; set; }
        public override string ToString() => Naziv;
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return IDDrzava.Equals(obj);
        }
        public override int GetHashCode()
        {
            return IDDrzava.GetHashCode();
        }
    }
}