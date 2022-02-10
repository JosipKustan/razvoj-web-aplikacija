using RWA_Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using static RWA_Projekt.Models.Proizvod;

namespace RWA_Projekt.Controllers
{
    public class ProizvodController : Controller
    {
        // GET: Proizvod
        public ActionResult Index()
        {
            return View(Repo.RepoSingleton.GetInstance().GetProizvodAll());
        }

        // GET: Proizvod/Details/5
        public ActionResult Details(int id)
        {
            if (id<1)
            {
                return RedirectToAction("Index");
            }
            return View(Repo.RepoSingleton.GetInstance().GetProizvod(id));
        }

        // GET: Proizvod/Create
        public ActionResult Create()
        {
            var potkategorije = Repo.RepoSingleton.GetInstance().GetPotkategorijaAll();
            ViewBag.PotkategorijeBind = new SelectList(potkategorije, "IDPotkategorija", "Naziv");
            return View();
        }

        // POST: Proizvod/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Repo.RepoSingleton.GetInstance().CreateProizvod(
                    new Models.Proizvod { 
                    Naziv=collection.Get("Naziv"),
                    BrojProizvoda = collection.Get("BrojProizvoda"),
                    MinimalnaKolicinaNaSkladistu = int.Parse(collection.Get("MinimalnaKolicinaNaSkladistu")),
                    CijenaBezPDV = decimal.Parse(collection.Get("CijenaBezPDV"))
                },
                    int.Parse(collection.Get("Potkategorije")),
                    Enum.Parse(typeof(Boja), collection.Get("Boje")).ToString()
                );
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Proizvod/Edit/5
        public ActionResult Edit(int id)
        {
            var proizvod = Repo.RepoSingleton.GetInstance().GetProizvod(id);
            var potkategorije = Repo.RepoSingleton.GetInstance().GetPotkategorijaAll();
            ViewBag.PotkategorijeBind = new SelectList(potkategorije, "IDPotkategorija", "Naziv",proizvod.Potkategorija?.IDPotkategorija);
            return View(proizvod);
        }

        // POST: Proizvod/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Repo.RepoSingleton.GetInstance().UpdateProizvod(new Proizvod { 
                    IDProizvod=id,
                    Naziv = collection.Get("Naziv"),
                    BrojProizvoda = collection.Get("BrojProizvoda"),
                    MinimalnaKolicinaNaSkladistu = int.Parse(collection.Get("MinimalnaKolicinaNaSkladistu")),
                    CijenaBezPDV = decimal.Parse(collection.Get("CijenaBezPDV"))
                },
                    int.Parse(collection.Get("Potkategorije")),
                    Enum.Parse(typeof(Boja), collection.Get("Boje")).ToString()
                );
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Proizvod/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Repo.RepoSingleton.GetInstance().GetProizvod(id));
        }

        // POST: Proizvod/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Repo.RepoSingleton.GetInstance().DeleteProizvod(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(Repo.RepoSingleton.GetInstance().GetProizvod(id));
            }
        }
    }
}
