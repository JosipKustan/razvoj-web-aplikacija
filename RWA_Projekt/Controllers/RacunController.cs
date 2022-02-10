using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWA_Projekt.Controllers
{
    public class RacunController : Controller
    {
        // GET: Racun
        public ActionResult Index()
        {
            return View(Repo.RepoSingleton.GetInstance().GetRacunAll());
        }

        // GET: Racun/Details/5
        public ActionResult Details(int id)
        {
            var racun = Repo.RepoSingleton.GetInstance().GetRacun(id);
            ViewBag.RacunCijena = racun.Stavke.Sum(stavka => stavka.UkupnaCijena);
            return View(racun);
        }

        // GET: Racun/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Racun/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Racun/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Racun/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Racun/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Racun/Delete/5
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
