using PagedList;
using RWA_Projekt.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWA_Projekt.Controllers
{
    public class KupacController : Controller
    {
        private const string PLACEHOLDER= "Odaberi državu";
        //List<Kupac> kupacs = new List<Kupac>() {
        //   new Kupac(){
        //       IDKupac=0,
        //       Ime="ime",
        //       Prezime="Prezime",
        //       Email="mail@fds.com",
        //       Grad= new Grad(){ 
        //        IDGrad=1,
        //        Drzava=new
        //       },

        //    },
        //};
        // GET: Kupac
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page, string grad, string gradovi_BiH, string gradovi_Hrvatske, string gradovi_Njemacke)
        {
            IEnumerable<Kupac> kupacs = null;
            string gradQuary=null;
            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.ImeSortParm = sortOrder=="ime" ? "ime_desc" : "ime";
            ViewBag.PrezimeSortParm = sortOrder=="prezime" ? "prezime_desc" : "prezime";
            IList<Drzava> drzave= GetDrzave();
            ViewBag.Drzave = drzave;
            try
            {
                ViewBag.GradoviHrvatske = GetGradoviDrzave(drzave.First(drzava => drzava.Naziv.Equals("Hrvatska")));
                ViewBag.GradoviBiH = GetGradoviDrzave(drzave.First(drzava => drzava.Naziv.Equals("Bosna i Hercegovina")));
                ViewBag.GradoviNjemacke = GetGradoviDrzave(drzave.First(drzava => drzava.Naziv.Equals("Njemačka")));
                gradQuary = gradovi_BiH + gradovi_Hrvatske + gradovi_Njemacke;
            }
            catch (Exception)
            {

            }
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            //GET: KUPAC
            if (gradQuary!= null && gradQuary.Count() > 0)
            {
                kupacs = Repo.RepoSingleton.GetInstance().GetKupacAllGrad(gradQuary);
            }
            else
            {
                kupacs = Repo.RepoSingleton.GetInstance().GetKupacAll();
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                kupacs = kupacs.Where(k => k.Ime.Contains(searchString)
                                       || k.Prezime.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "ime_desc":
                    kupacs = kupacs.OrderByDescending(k => k.Ime);
                    break;
                case "ime":
                    kupacs = kupacs.OrderBy(s => s.Ime);
                    break;
                case "prezime_desc":
                    kupacs = kupacs.OrderByDescending(k => k.Prezime);
                    break;
                case "prezime":
                    kupacs = kupacs.OrderBy(s => s.Prezime);
                    break;
                case "id_desc":
                    kupacs = kupacs.OrderByDescending(s => s.IDKupac);
                    break;
                default:
                    kupacs = kupacs.OrderBy(k => k.IDKupac);
                    break;
            }
            int pageSize = 50;
            int pageNumber = (page ?? 1);
            return View(kupacs.ToPagedList(pageNumber, pageSize));
        }

        private IList<Grad> GetGradoviDrzave(Drzava drzava)
        {
            return Repo.RepoSingleton.GetInstance().GetGradAllDrzava(drzava.IDDrzava).ToList();
        }

        private IList<Drzava> GetDrzave()
        {
            IList<Drzava> drzave = new List<Drzava>();
            drzave.Add(new Drzava()
            {
                Naziv = PLACEHOLDER
            });
            foreach (Drzava drzava in Repo.RepoSingleton.GetInstance().GetDrzavaAll())
            {
                drzave.Add(drzava);
            }

            return drzave;
        }

        // GET: Kupac/Details/5
        public ActionResult Details(int id)
        {
            return View(Repo.RepoSingleton.GetInstance().GetKupac(id));
        }

        // GET: Kupac/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kupac/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Kupac/Edit/5
        public ActionResult Edit(int id)
        {

            ViewBag.Drzave = Repo.RepoSingleton.GetInstance().GetDrzavaAll().ToList();
            ViewBag.Gradovi = Repo.RepoSingleton.GetInstance().GetGradAll().ToList();
            return View(Repo.RepoSingleton.GetInstance().GetKupac(id));
        }

        // POST: Kupac/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                
                Kupac kupac = Repo.RepoSingleton.GetInstance().GetKupac(id);

                kupac.Ime = collection.Get("Ime");
                kupac.Prezime = collection.Get("Prezime");
                kupac.Email = collection.Get("Email");
                kupac.Telefon = collection.Get("Telefon");
                Grad grad = Repo.RepoSingleton.GetInstance().GetGrad(int.Parse(collection.Get("Grad.IDGrad")));
                kupac.Grad = grad;

                Repo.RepoSingleton.GetInstance().UpdateKupac(kupac);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Kupac/Delete/5
        public ActionResult Delete(int id)
        {

            return View(Repo.RepoSingleton.GetInstance().GetKupac(id));
        }

        // POST: Kupac/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
