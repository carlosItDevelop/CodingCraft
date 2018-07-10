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
    public class HistoriaPatologicaPregressaController : Controller
    {
        private MedicalManagementDbContext db = new MedicalManagementDbContext();

        // GET: HistoriaPatologicaPregressa
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Listar()
        {
            return View(db.HistoriaPatologicaPregressa.ToList());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult getHPPregressa()
        {
            var hhpdesc = (from h in db.HistoriaPatologicaPregressa select h).ToList();

            return Json(hhpdesc, JsonRequestBehavior.AllowGet);
        }



        // GET: HistoriaPatologicaPregressa/Details/5
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
            HistoriaPatologicaPregressa historiaPatologicaPregressa = db.HistoriaPatologicaPregressa.Find(id);
            if (historiaPatologicaPregressa == null)
            {
                return HttpNotFound();
            }
            return View(historiaPatologicaPregressa);
        }

        // GET: HistoriaPatologicaPregressa/Create
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        // POST: HistoriaPatologicaPregressa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="historiaPatologicaPregressa"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HistoriaPatologicaPregressaId,Descricao")] HistoriaPatologicaPregressa historiaPatologicaPregressa)
        {
            if (ModelState.IsValid)
            {
                db.HistoriaPatologicaPregressa.Add(historiaPatologicaPregressa);
                db.SaveChanges();
                return RedirectToAction("Listar");
            }

            return View(historiaPatologicaPregressa);
        }

        // GET: HistoriaPatologicaPregressa/Edit/5
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
            HistoriaPatologicaPregressa historiaPatologicaPregressa = db.HistoriaPatologicaPregressa.Find(id);
            if (historiaPatologicaPregressa == null)
            {
                return HttpNotFound();
            }
            return View(historiaPatologicaPregressa);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="historiaPatologicaPregressa"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HistoriaPatologicaPregressaId,Descricao")] HistoriaPatologicaPregressa historiaPatologicaPregressa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historiaPatologicaPregressa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Listar");
            }
            return View(historiaPatologicaPregressa);
        }

        // GET: HistoriaPatologicaPregressa/Delete/5
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
            HistoriaPatologicaPregressa historiaPatologicaPregressa = db.HistoriaPatologicaPregressa.Find(id);
            if (historiaPatologicaPregressa == null)
            {
                return HttpNotFound();
            }
            return View(historiaPatologicaPregressa);
        }

        // POST: HistoriaPatologicaPregressa/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HistoriaPatologicaPregressa historiaPatologicaPregressa = db.HistoriaPatologicaPregressa.Find(id);
            db.HistoriaPatologicaPregressa.Remove(historiaPatologicaPregressa);
            db.SaveChanges();
            return RedirectToAction("Listar");
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
