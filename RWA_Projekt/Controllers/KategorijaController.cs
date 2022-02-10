using RWA_Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWA_Projekt.Controllers
{
    public class KategorijaController : Controller
    {
        // GET: Kategorija
        public ActionResult Index()
        {
            return View(Repo.RepoSingleton.GetInstance().GetKategorijaAll());
        }

        // GET: Kategorija/Details/5
        public ActionResult Details(int id)
        {
            return View(Repo.RepoSingleton.GetInstance().GetKategorija(id));
        }

        // GET: Kategorija/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kategorija/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Repo.RepoSingleton.GetInstance().CreateKategorija(collection.Get("Naziv"));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Kategorija/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Repo.RepoSingleton.GetInstance().GetKategorija(id));
        }

        // POST: Kategorija/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Repo.RepoSingleton.GetInstance().UpdateKategorija(new Kategorija { 
                    IDKategorija=id,
                    Naziv=collection.Get("Naziv")
                });
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Kategorija/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Repo.RepoSingleton.GetInstance().GetKategorija(id));
        }

        // POST: Kategorija/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Repo.RepoSingleton.GetInstance().DeleteKategorija(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
