using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RWA_Projekt.Repo
{
    public static class RepoSingleton
    {
        private static SqlRepo obj = null;
        private static readonly object padLock = new object();
        private static string connectionString = ConfigurationManager.ConnectionStrings["local"].ConnectionString;

        public static SqlRepo GetInstance()
        {
            lock (padLock)
            {
                if (obj == null)
                {
                    //hidden uuuu
                    obj = new SqlRepo(connectionString);
                }
            }
            return obj;
        }
    }
}
