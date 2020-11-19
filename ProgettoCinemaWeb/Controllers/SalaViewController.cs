using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgettoCinemaWeb.Controllers
{
    public class SalaViewController : Controller
    {
        // GET: SalaView
        public ActionResult Index()
        {
            return View();
        }

        // GET: SalaView/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SalaView/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalaView/Create
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

        // GET: SalaView/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SalaView/Edit/5
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

        // GET: SalaView/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SalaView/Delete/5
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
