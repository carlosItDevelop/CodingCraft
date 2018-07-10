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
    public class ComplicacaoController : Controller
    {
        private MedicalManagementDbContext db = new MedicalManagementDbContext();

        // GET: Complicacao
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(db.Complicacao.ToList());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult getComplicacao()
        {
            var complic = (from c in db.Complicacao select c).ToList();
            return Json(complic, JsonRequestBehavior.AllowGet);
        }
        


        // GET: Complicacao/Details/5
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
            Complicacao complicacao = db.Complicacao.Find(id);
            if (complicacao == null)
            {
                return HttpNotFound();
            }
            return View(complicacao);
        }

        // GET: Complicacao/Create
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
        /// <param name="complicacao"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComplicacaoId,Descricao")] Complicacao complicacao)
        {
            if (ModelState.IsValid)
            {
                db.Complicacao.Add(complicacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(complicacao);
        }

        // GET: Complicacao/Edit/5
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
            Complicacao complicacao = db.Complicacao.Find(id);
            if (complicacao == null)
            {
                return HttpNotFound();
            }
            return View(complicacao);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="complicacao"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComplicacaoId,Descricao")] Complicacao complicacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complicacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(complicacao);
        }

        // GET: Complicacao/Delete/5
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
            Complicacao complicacao = db.Complicacao.Find(id);
            if (complicacao == null)
            {
                return HttpNotFound();
            }
            return View(complicacao);
        }

        // POST: Complicacao/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Complicacao complicacao = db.Complicacao.Find(id);
            db.Complicacao.Remove(complicacao);
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
