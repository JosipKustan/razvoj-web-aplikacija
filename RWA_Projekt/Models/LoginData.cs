using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA_Projekt.Models
{
    [Serializable]
    public class LoginData
    {
        public int IDLoginData { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return IDLoginData.Equals(obj);
        }
        public override int GetHashCode()
        {
            return IDLoginData.GetHashCode();
        }
    }
}