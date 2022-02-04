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
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page, string grad)
        {
            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.ImeSortParm = sortOrder=="ime" ? "ime_desc" : "ime";
            ViewBag.PrezimeSortParm = sortOrder=="prezime" ? "prezime_desc" : "prezime";

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
            var kupacs = Repo.RepoSingleton.GetInstance().GetKupacAll();

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
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(kupacs.ToPagedList(pageNumber, pageSize));
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
            return View(Repo.RepoSingleton.GetInstance().GetKupac(id));
        }

        // POST: Kupac/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Debug.WriteLine(collection);
                // TODO: Add update logic here
                
                Kupac kupac = Repo.RepoSingleton.GetInstance().GetKupac(id);

                kupac.Ime = collection.Get("Ime");
                kupac.Prezime = collection.Get("Prezime");
                kupac.Email = collection.Get("Email");
                kupac.Telefon = collection.Get("Telefon");
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
