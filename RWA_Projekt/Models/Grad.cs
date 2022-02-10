using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA_Projekt.Models
{
    [Serializable]
    public class Grad
    {
        public int IDGrad { get; set; }
        public string Naziv { get; set; }
        public Drzava Drzava { get; set; }

        public override string ToString()
        {
            return Naziv;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            if (obj is Grad grad)
            {
                return grad.IDGrad.Equals(IDGrad);
            }
            else
            {
                return false;
            }

        }
        public override int GetHashCode()
        {
            return IDGrad.GetHashCode();
        }
    }
}