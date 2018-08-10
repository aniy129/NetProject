using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Csk.Development.JsValidate.Models;

namespace Csk.Development.JsValidate.Controllers
{
    public class MyController : Controller
    {
        private jsvalidateEntities db = new jsvalidateEntities();
        // GET: My
        public ActionResult Index()
        {

            return View(db.Test.ToList());
        }

        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var t = db.Test.Find(id);
            if (t==null)
            {
                return HttpNotFound();
            }
            return View(t);
        }
        //ModelState["Phone"].Errors[0]  获取某个字段的错误信息
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Names,Age,Phone,Reamrk")] Test test)
        {
            if (ModelState.IsValid)
            {
                db.Entry(test).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(test);
        }
    }
}