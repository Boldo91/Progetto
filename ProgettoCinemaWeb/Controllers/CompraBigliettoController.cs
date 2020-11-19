using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgettoCinemaWeb.Controllers
{
    public class CompraBigliettoController : Controller
    {
        // GET: CompraBiglietto
        public ActionResult Index()
        {
            return View();
        }

        // GET: CompraBiglietto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CompraBiglietto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompraBiglietto/Create
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

        // GET: CompraBiglietto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CompraBiglietto/Edit/5
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

        // GET: CompraBiglietto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CompraBiglietto/Delete/5
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
