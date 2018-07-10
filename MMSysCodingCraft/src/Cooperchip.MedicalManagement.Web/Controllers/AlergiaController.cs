using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cooperchip.MedicalManagement.Infra.Data;
using Cooperchip.MedicalManagement.Domain.Entidade;

namespace Cooperchip.MedicalManagement.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class AlergiaController : Controller
    {
        private MedicalManagementDbContext db = new MedicalManagementDbContext();

        // GET: Alergia
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(db.Alergia.ToList());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAlergia()
        {
            var alergia = (from a in db.Alergia select a).ToList();

            return Json(alergia, JsonRequestBehavior.AllowGet);
        }

        // GET: Alergia/Details/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alergia alergia = db.Alergia.Find(id);
            if (alergia == null)
            {
                return HttpNotFound();
            }
            return View(alergia);
        }

        // GET: Alergia/Create
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alergia"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlergiaId,Descricao")] Alergia alergia)
        {
            if (ModelState.IsValid)
            {
                db.Alergia.Add(alergia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alergia);
        }

        // GET: Alergia/Edit/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alergia alergia = db.Alergia.Find(id);
            if (alergia == null)
            {
                return HttpNotFound();
            }
            return View(alergia);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alergia"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlergiaId,Descricao")] Alergia alergia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alergia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alergia);
        }

        // GET: Alergia/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alergia alergia = db.Alergia.Find(id);
            if (alergia == null)
            {
                return HttpNotFound();
            }
            return View(alergia);
        }

        // POST: Alergia/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alergia alergia = db.Alergia.Find(id);
            db.Alergia.Remove(alergia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
