using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWA_Projekt.Controllers
{
    public class PotkategorijaController : Controller
    {
        // GET: Potkategorija
        public ActionResult Index(string searchString)
        {
            List<String> nazivi = new List<string>();
            var potkategorije = Repo.RepoSingleton.GetInstance().GetPotkategorijaAll();
            foreach (var potk in potkategorije)
            {
                nazivi.Add(potk.Naziv);
            }
            ViewBag.Nazivi = nazivi;
            if (!String.IsNullOrEmpty(searchString))
            {
                potkategorije = potkategorije.Where(k => k.Naziv.Contains(searchString)
                                       || k.IDPotkategorija.ToString().Equals(searchString));
            }
            return View(potkategorije);
        }

        // GET: Potkategorija/Details/5
        public ActionResult Details(int id)
        {
            return View(Repo.RepoSingleton.GetInstance().GetPotkategorija(id));
        }

        // GET: Potkategorija/Create
        public ActionResult Create()
        {
            var kategorije = Repo.RepoSingleton.GetInstance().GetKategorijaAll();
            ViewBag.KategorijeBind = new SelectList(kategorije, "IdKategorija","Naziv");
            
            return View();
        }

        // POST: Potkategorija/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                
                Repo.RepoSingleton.GetInstance().CreatePotkategorija(collection.Get("Naziv"), int.Parse(collection.Get("Kategorije")));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Potkategorija/Edit/5
        public ActionResult Edit(int id)
        {
            var potkategorija = Repo.RepoSingleton.GetInstance().GetPotkategorija(id);
            var kategorije = Repo.RepoSingleton.GetInstance().GetKategorijaAll();
            ViewBag.KategorijeBind = new SelectList(kategorije, "IdKategorija", "Naziv",potkategorija.Kategorija.IDKategorija);
            return View(potkategorija);
        }

        // POST: Potkategorija/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Repo.RepoSingleton.GetInstance().UpdatePotkategorija(new Models.Potkategorija
                {
                    IDPotkategorija = id,
                    Naziv=collection.Get("Naziv")
                },
                int.Parse(collection.Get("Kategorije")));
                return RedirectToAction("Index");
            }
            catch
            {
                return View(Repo.RepoSingleton.GetInstance().GetPotkategorija(id));
            }
        }

        // GET: Potkategorija/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Repo.RepoSingleton.GetInstance().GetPotkategorija(id));
        }

        // POST: Potkategorija/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Repo.RepoSingleton.GetInstance().DeletePotkategorija(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(Repo.RepoSingleton.GetInstance().GetPotkategorija(id));
            }
        }
    }
}
