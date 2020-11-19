using ProgettoCinema.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgettoCinemaWeb.Controllers
{
    public class FilmViewController : Controller
    {
        private readonly FilmSqlProvider filmSqlProvider;
        public FilmViewController()
        {
            filmViewController = new FilmViewController();
        }
        // GET: FilmView
        public ActionResult Index()
        {
            var film=filmViewController.
            return View();
        }

        // GET: FilmView/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FilmView/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FilmView/Create
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

        // GET: FilmView/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FilmView/Edit/5
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

        // GET: FilmView/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FilmView/Delete/5
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
