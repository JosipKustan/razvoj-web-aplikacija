using Microsoft.ApplicationBlocks.Data;
using RWA_Projekt.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using static RWA_Projekt.Models.Proizvod;

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

        public IEnumerable<Kupac> GetKupacAllGrad(int idGrad)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "selectKupacAllGrad",idGrad);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetKupacFromDataRow(row);
            }
        }
        public IEnumerable<Kupac> GetKupacAllGrad(string nazivGrada)
        {
            var gradovi=GetGradAll();

            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "selectKupacAllGrad", (gradovi.First(grad=>grad.Naziv.Equals(nazivGrada))).IDGrad);
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
                    Kupac.Telefon.WithMaxLength(25),
                    Kupac.Grad.IDGrad
                );
        }

        private Kupac GetKupacFromDataRow(DataRow row)
        {
            int result;
            var grad = int.TryParse(row["GradID"].ToString(), out result) ? GetGrad(result) : GetGrad(0);
            return new Kupac
            {
                IDKupac = (int)row["IDKupac"],
                Ime = row["Ime"].ToString(),
                Prezime = row["Prezime"].ToString(),
                Email = row["Email"].ToString(),
                Telefon = row["Telefon"].ToString(),
                Grad=grad
            };
        }
        //----------------------------------------------
        //---KOMERCIALIST-------------------------------------
        //----------------------------------------------
        public Komercijalist GetKomercijalist(int idKomercijalist)
        {
            if (idKomercijalist <= 0)
            {
                return null;
            }
            return GetKomercijalistFromDataRow(SqlHelper.ExecuteDataset(ConnectionString, "selectKomercijalist", idKomercijalist).Tables[0].Rows[0]);
               
        }
        public IEnumerable<Komercijalist> GetMultipleKomercijalist()
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "selectKomercijalistAll");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetKomercijalistFromDataRow(row);
            }
        }
        private Komercijalist GetKomercijalistFromDataRow(DataRow row)
        {
            return new Komercijalist
            {
                IDKomercijalist = (int)row["IDKomercijalist"],
                Ime = row["Ime"].ToString(),
                Prezime = row["Prezime"].ToString(),
                StalniZaposlenik = (bool)row["StalniZaposlenik"]
            };
        }

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

        public IEnumerable<Drzava> GetDrzavaAll()
        {

            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "selectDrzavaAll");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetDrzavaFromDataRow(row);
            }
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
        public int CreateKategorija(String nazivKategorije)
        {
            int IDKategorija = int.Parse(SqlHelper.ExecuteScalar(ConnectionString, "createKategorija", nazivKategorije.WithMaxLength(50)).ToString());
            if (IDKategorija > 0)
            {
                return IDKategorija;
            }
            return 0;
        }
        public Kategorija GetKategorija(int IDKategorija)
        {
            if (IDKategorija <= 0)
            {
                return null;
            }
            Kategorija Kategorija;
            Kategorija = GetKategorijaFromDataRow(
                    SqlHelper.ExecuteDataset(ConnectionString, "selectKategorija", IDKategorija).Tables[0].Rows[0]);
                return Kategorija;
        }
        public IEnumerable<Kategorija> GetKategorijaAll()
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "selectKategorijaAll");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetKategorijaFromDataRow(row);
            }
        }
        public int UpdateKategorija(Kategorija kategorija)
        {
            int rows = SqlHelper.ExecuteNonQuery(ConnectionString,"updateKategorija",
                    kategorija.IDKategorija,
                    kategorija.Naziv.WithMaxLength(50)
                );

            if (rows > 0)
            {
                return rows;
            }
            return 0;
        }
        public void DeleteKategorija(int idKategorija)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString, "deleteKategorija", idKategorija);
        }
        private Kategorija GetKategorijaFromDataRow(DataRow row)
        {
            return new Kategorija
            {
                IDKategorija = (int)row["IDKategorija"],
                Naziv = row["Naziv"].ToString()
            };
        }
        //----------------------------------------------
        //---PODKATEGORIJA-------------------------------------
        //----------------------------------------------
        public int CreatePotkategorija(string nazivPotkategorije, int kategorijaID = 0)
        {
            int IDPotkategorija = int.Parse(SqlHelper.ExecuteScalar(ConnectionString, "createPotkategorija",
                kategorijaID,
                nazivPotkategorije.WithMaxLength(50)).ToString());

            if (IDPotkategorija > 0)
            {
                return IDPotkategorija;
            }
            return 0;
        }
        public Potkategorija GetPotkategorija(int IDPotkategorija)
        {
            if (IDPotkategorija <= 0)
            {
                return null;
            }
            return GetPotkategorijaFromDataRow(SqlHelper.ExecuteDataset(ConnectionString, "selectPotkategorija", IDPotkategorija).Tables[0].Rows[0]);

        }
        public IEnumerable<Potkategorija> GetPotkategorijaAll()
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "selectPotkategorijaAll");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetPotkategorijaFromDataRow(row);
            }
        }
        public IEnumerable<Potkategorija> GetPotkategorijaAllKategorija(int kategorijaID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "selectPotkategorijaAllKategorija", kategorijaID);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetPotkategorijaFromDataRow(row);
            }
        }

        public int UpdatePotkategorija(Potkategorija potkategorija, int kategorijaID)
        {
            int rows = SqlHelper.ExecuteNonQuery(ConnectionString, "updatePotkategorija",
                    potkategorija.IDPotkategorija,
                    kategorijaID,
                    potkategorija.Naziv.WithMaxLength(50)
                );
            if (rows > 0)
            {
                return rows;
            }
            return 0;
        }
        public void DeletePotkategorija(int idPotkategorija)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString, "deletePotkategorija", idPotkategorija);
        }
        private Potkategorija GetPotkategorijaFromDataRow(DataRow row)
        {
            int result;
            var Kategorija = int.TryParse(row["KategorijaID"].ToString(), out result) ? GetKategorija(result) : GetKategorija(0);
            return new Potkategorija
            {
                IDPotkategorija = (int)row["IDPotkategorija"],
                Naziv = row["Naziv"].ToString(),
                Kategorija = Kategorija
            };
        }
    //----------------------------------------------
    //---PROIZVOD-------------------------------------
    //----------------------------------------------
        public int CreateProizvod(Proizvod Proizvod,int potkategorijaID=0,string boja="nocolor")
        {
            int IDProizvod = int.Parse(SqlHelper.ExecuteScalar(ConnectionString, "createProizvod",
                Proizvod.Naziv.WithMaxLength(50),
                Proizvod.BrojProizvoda,
                boja,
                Proizvod.MinimalnaKolicinaNaSkladistu,
                Proizvod.CijenaBezPDV,
                potkategorijaID
            ).ToString());
            if (IDProizvod > 0)
            {
                return IDProizvod;
            }
            return 0;
        }
        public Proizvod GetProizvod(int IDProizvod)
        {
            if (IDProizvod <= 0)
            {
                return null;
            }
            return GetProizvodFromDataRow(SqlHelper.ExecuteDataset(ConnectionString, "selectProizvod", IDProizvod).Tables[0].Rows[0]);
                
        }
        public IEnumerable<Proizvod> GetProizvodAll()
        {
                DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "selectProizvodAll");
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    yield return GetProizvodFromDataRow(row);
                }
               
        }
        public int UpdateProizvod(Proizvod proizvod, int potkategorijaID = 0, string boja = "nocolor")
        {
            int rows = SqlHelper.ExecuteNonQuery(ConnectionString,"updateProizvod",
                    proizvod.IDProizvod,
                    proizvod.Naziv.WithMaxLength(50),
                    proizvod.BrojProizvoda,
                    boja,
                    proizvod.MinimalnaKolicinaNaSkladistu,
                    proizvod.CijenaBezPDV,
                    potkategorijaID
                );
            if (rows > 0)
            {
                return rows;
            }
            return 0;
        }

        public void DeleteProizvod(int idProizvod)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString, "deleteProizvod", idProizvod);
        }
        private Proizvod GetProizvodFromDataRow(DataRow row)
        {
            int result;
            var Potkategorija = int.TryParse(row["PotkategorijaID"].ToString(), out result) ? GetPotkategorija(result) : GetPotkategorija(0);
            return new Proizvod
            {
                IDProizvod = (int)row["IDProizvod"],
                Naziv = row["Naziv"].ToString(),
                BrojProizvoda = row["BrojProizvoda"].ToString(),
                MinimalnaKolicinaNaSkladistu = (short)row["MinimalnaKolicinaNaSkladistu"],
                BojaProizvoda = DetermineBojaProizvod(row["Boja"].ToString()),
                CijenaBezPDV = (decimal)row["CijenaBezPDV"],
                Potkategorija = Potkategorija
            };
        }
        
        //----------------------------------------------
        //---KREDITNA KARTICA-------------------------------------
        //----------------------------------------------
        public KreditnaKartica GetKreditnaKartica(int idKreditnaKartica)
        {
            if (idKreditnaKartica <= 0)
            {
                return null;
            }
            return GetKreditnaKarticaFromDataRow(SqlHelper.ExecuteDataset(ConnectionString, "selectKreditnaKartica", idKreditnaKartica).Tables[0].Rows[0]);
               
        }
        public KreditnaKartica GetKreditnaKartica(string brojKartice)
        {
            if (brojKartice.Length <= 0)
            {
                return null;
            }
            return GetKreditnaKarticaFromDataRow(SqlHelper.ExecuteDataset(ConnectionString, "selectKreditnaKarticaBroj", brojKartice).Tables[0].Rows[0]);
        }
        public IEnumerable<KreditnaKartica> GetKreditnaKarticaAll()
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "selectKreditnaKarticaAll");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetKreditnaKarticaFromDataRow(row);
            }
        }
        private KreditnaKartica GetKreditnaKarticaFromDataRow(DataRow row)
        {
            return new KreditnaKartica
            {
                IDKreditnaKartica = (int)row["IDKreditnaKartica"],
                Broj = row["Broj"].ToString(),
                IstekGodina = (short)row["IstekGodina"],
                IstekMjesec = short.Parse(row["IstekMjesec"].ToString()),
                Tip = DetermineTipKreditnaKartica(row["Tip"].ToString())

            };
        }
        public static TipKreditnaKartica DetermineTipKreditnaKartica(string stringtip)
        {
            switch (stringtip)
            {
                case "American Express":
                    return TipKreditnaKartica.AmericanExpress;
                case "Diners":
                    return TipKreditnaKartica.Diners;
                case "MasterCard":
                    return TipKreditnaKartica.MasterCard;
                case "Visa":
                    return TipKreditnaKartica.Visa;
                default:
                    return TipKreditnaKartica.Other;
            }
        }
        //----------------------------------------------
        //---RAČUN-------------------------------------
        //----------------------------------------------
        public Racun GetRacun(int idRacun)
        {
            if (idRacun <= 0)
            {
                return null;
            }
            return GetRacunFromDataRow(SqlHelper.ExecuteDataset(ConnectionString, "selectRacun", idRacun).Tables[0].Rows[0]);
        }
        public IEnumerable<Racun> GetRacunAll()
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "selectRacunAll");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetRacunFromDataRow(row);
            }
        }
        public IEnumerable<Racun> GetRacunAllKupac(int kupacID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "selectRacunAllKupac",kupacID);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetRacunFromDataRow(row);
            }
        }
        private Racun GetRacunFromDataRow(DataRow row)
        {
            int result;
            Komercijalist komercijalist = int.TryParse(row["KomercijalistID"].ToString(), out result) ? GetKomercijalist(result) : null;
            KreditnaKartica kreditnaKartica = int.TryParse(row["KreditnaKarticaID"].ToString(), out result) ? GetKreditnaKartica(result) : null;
            Kupac kupac = int.TryParse(row["KupacID"].ToString(), out result) ? GetKupac(result) : GetKupac(0);
            List<Stavka> stavke = GetStavkaAllRacun((int)row["IDRacun"]).ToList();
            return new Racun
            {
                IDRacun = (int)row["IDRacun"],
                BrojRacuna = row["BrojRacuna"].ToString(),
                DatumIzdavanja = DateTime.Parse(row["DatumIzdavanja"].ToString()),
                Komentar = row["Komentar"].ToString(),
                Komercijalist = komercijalist,
                KreditnaKartica = kreditnaKartica,
                Stavke = stavke,
                Kupac = kupac
            };
        }
        //----------------------------------------------
        //---Stavka-------------------------------------
        //----------------------------------------------

        public Stavka GetStavka(int idStavka)
        {
            if (idStavka <= 0)
            {
                return null;
            }
            return GetStavkaFromDataRow(SqlHelper.ExecuteDataset(ConnectionString, "selectStavka", idStavka).Tables[0].Rows[0]);
              
        }
        public IEnumerable<Stavka> GetStavkaAll()
        {
           
                DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "selectStavkaAll");
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    yield return GetStavkaFromDataRow(row);
                }
                
        }
        public IEnumerable<Stavka> GetStavkaAllRacun(int idRacun)
        {
                DataSet ds = SqlHelper.ExecuteDataset(ConnectionString, "selectStavkaAllRacun", idRacun);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    yield return GetStavkaFromDataRow(row);
                }
                
        }
        private Stavka GetStavkaFromDataRow(DataRow row)
        {
            int result;
            var Proizvod = int.TryParse(row["ProizvodID"].ToString(), out result) ? GetProizvod(result) : GetProizvod(0);
            var Racun = int.TryParse(row["RacunID"].ToString(), out result) ? result : 0;
            return new Stavka
            {
                IDStavka = (int)row["IDStavka"],
                CijenaPoKomadu = (decimal)row["CijenaPoKomadu"],
                Kolicina = (short)row["Kolicina"],
                PopustUPostocima = (decimal)row["PopustUPostocima"],
                Proizvod = Proizvod,
                RacunID = Racun,
                UkupnaCijena = (decimal)row["UkupnaCijena"]
            };
        }

    }
}