using Microsoft.ApplicationBlocks.Data;
using RWA_Projekt.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace RWA_Projekt.Repo
{
    public class SqlRepo
    {
        public string ConnectionString { get; set; }

        public SqlRepo(string connectionString)
        {
            ConnectionString = connectionString;
        }

        //----------------------------------------------
        //---KUPAC-------------------------------------
        //----------------------------------------------
        public Kupac GetKupac(int idKupac)
        {
            if (idKupac <= 0)
            {
                return null;
            }
            
            return GetKupacFromDataRow(SqlHelper.ExecuteDataset(ConnectionString, "selectKupac", idKupac).Tables[0].Rows[0]);
            
        }

        public IEnumerable<Kupac> GetKupacAll()
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "selectKupacAll");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetKupacFromDataRow(row);
            }
        }

        public int UpdateKupac(Kupac Kupac)
        {
            return SqlHelper.ExecuteNonQuery(ConnectionString,"updateKupac",
                    Kupac.IDKupac,
                    Kupac.Ime.WithMaxLength(50),
                    Kupac.Prezime.WithMaxLength(50),
                    Kupac.Email.WithMaxLength(50),
                    Kupac.Telefon.WithMaxLength(25)
                );
        }

        private Kupac GetKupacFromDataRow(DataRow row)
        {
            //TODO add Grad to Kupac (bilo bi super da je id only)
            return new Kupac
            {
                IDKupac = (int)row["IDKupac"],
                Ime = row["Ime"].ToString(),
                Prezime = row["Prezime"].ToString(),
                Email = row["Email"].ToString(),
                Telefon = row["Telefon"].ToString(),
            };
        }
    //----------------------------------------------
    //---KOMERCIALIST-------------------------------------
    //----------------------------------------------


    //----------------------------------------------
    //---DRZAVA-------------------------------------
    //----------------------------------------------
    public Drzava GetDrzava(int IDDrzava)
        {
            if (IDDrzava <= 0)
            {
                return null;
            }

            return GetDrzavaFromDataRow(SqlHelper.ExecuteDataset(ConnectionString, "selectDrzava", IDDrzava).Tables[0].Rows[0]);
        }
        private Drzava GetDrzavaFromDataRow(DataRow row)
        {
            return new Drzava
            {
                IDDrzava = (int)row["IDDrzava"],
                Naziv = row["Naziv"].ToString()
            };
        }

        //----------------------------------------------
        //---GRAD-------------------------------------
        //----------------------------------------------
        public Grad GetGrad(int IDGrad)
        {
            if (IDGrad <= 0)
            {
                return null;
            }
            return GetGradFromDataRow(SqlHelper.ExecuteDataset(ConnectionString, "selectGrad", IDGrad).Tables[0].Rows[0]);
               
        }
        public IEnumerable<Grad> GetGradAll()
        {
            
                DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "selectGradAll");
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    yield return GetGradFromDataRow(row);
                }
        }
        public IEnumerable<Grad> GetGradAllDrzava(int DrzavaID)
        {

            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "selectGradAllDrzava",DrzavaID);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetGradFromDataRow(row);
            }
        }
        private Grad GetGradFromDataRow(DataRow row)
        {
            int result;
            var Drzava = int.TryParse(row["DrzavaID"].ToString(), out result) ? GetDrzava(result) : GetDrzava(0);
            return new Grad
            {
                IDGrad = (int)row["IDGrad"],
                Naziv = row["Naziv"].ToString(),
                Drzava = Drzava
            };
        }

        //----------------------------------------------
        //---KATEGORIJA-------------------------------------
        //----------------------------------------------

        //----------------------------------------------
        //---PODKATEGORIJA-------------------------------------
        //----------------------------------------------

        //----------------------------------------------
        //---PROIZVOD-------------------------------------
        //----------------------------------------------

        //----------------------------------------------
        //---KREDITNA KARTICA-------------------------------------
        //----------------------------------------------


    }
}