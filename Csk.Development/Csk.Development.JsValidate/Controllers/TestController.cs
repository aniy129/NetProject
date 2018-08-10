using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Csk.Development.JsValidate.Models;

namespace Csk.Development.JsValidate.Controllers
{
    public class TestController : Controller
    {
        private jsvalidateEntities db = new jsvalidateEntities();
        // GET: Test
        public ActionResult Index()
        {
            var model = db.Test;
            return View(model);
        }

        // GET: Test/Details/5
        public ActionResult Details(int id)
        {
            var dt = db.Test.FirstOrDefault(c => c.Id == id);
            return View(dt);
        }

        // GET: Test/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Test/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var test = new Test();
                   var rs= TryUpdateModel<Test>(test, collection);
                    
                    if (rs)
                    {
                        db.Test.Add(test);
                        db.SaveChanges();
                    }
                   
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Test/Edit/5
        public ActionResult Edit(int id)
        {
            var t = db.Test.FirstOrDefault(c => c.Id == id);
            return View(t);
        }

        // POST: Test/Edit/5
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

        // GET: Test/Delete/5
        public ActionResult Delete(int id)
        {
            var t = db.Test.FirstOrDefault(c => c.Id == id);
            return View(t);
        }

        // POST: Test/Delete/5
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

        public JsonResult Remote(string email)
        {
            var rs= email.Trim()== "csk@163.com";
            return Json(!rs, JsonRequestBehavior.AllowGet);
        }
    }
}
