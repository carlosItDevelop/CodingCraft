using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Cooperchip.MedicalManagement.Domain.Entidade;
using Cooperchip.MedicalManagement.Infra.Data;
using Cooperchip.MedicalManagement.Services;
using Cooperchip.MedicalManagement.Web.ViewModel;

namespace Cooperchip.MedicalManagement.Web.Controllers
{

    /// <summary>
    /// 
    /// </summary>
    public class MuralController : Controller
    {
        private MedicalManagementDbContext db = new MedicalManagementDbContext();

        private MuralViewModel Get(int? id)
        {
            Mural mural = (from m in db.Mural
                                 where m.MuralId == id
                                 select m).FirstOrDefault();

            return mural == null ? null : new MuralViewModel(mural);
        }


        // GET: Mural
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public ActionResult Index(string filtro)
        {
            var objBusca = from b in db.Mural
                select b;

            //-----------/ Filtro -----------------//
            var dddList = new List<string>();
            var dddQuery = from d in db.Mural
                           orderby d.Titulo
                           select d.Titulo;
            dddList.AddRange(dddQuery.Distinct());
            ViewBag.filtro = new SelectList(dddList);

            if (!String.IsNullOrEmpty(filtro)) objBusca = objBusca.Where(x => x.Titulo == filtro);
            //-----------/ Fim Filtro ------------------//


            return View(objBusca.Select(x => new MuralViewModel()
            {                
                Data = x.Data,
                Autor = x.Autor,
                Aviso = x.Aviso,
                MuralId = x.MuralId,
                Titulo = x.Titulo
            }).ToList());

        }



        // GET: Mural/Details/5
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


            var model = Get(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }


        // GET: Mural/Create
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            ViewBag.DataMural = DateTime.Now;
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Credencial()
        {
            ViewBag.DataMural = DateTime.Now;
            return View();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="mural"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Credencial(Mural mural)
        { 

            if (ModelState.IsValid)
            {
                mural.Aviso += mural.Email;
                try
                {
                    db.Mural.Add(mural);
                    db.SaveChanges();
                    ViewBag.Success = "Credecial requisitada com sucesso!";
                }
                catch (Exception)
                {
                    ViewBag.Erro = "Confira a digitação";
                    ModelState.AddModelError("error_sendmail", "Confira a digitação");
                    return View("Credencial");
                }

                try
                {
                    Messages.EnviarEmail("evolumedsys@gmail.com", "Solicitação de Credencial - Evolumed-Sys", mural.Aviso);
                }
                catch (Exception ex)
                {
                    ViewBag.Erro = ex.Message;
                    ModelState.AddModelError("error_sendmail",ex.Message);
                    return View("Credencial");
                }

                return RedirectToAction("Login", "Account");
            }

            return View(mural);
        }




        // POST: Mural/Create
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mural"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mural mural)
        {
            if (ModelState.IsValid)
            {
                db.Mural.Add(mural);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mural);
        }

        
        // GET: Mural/Edit/5
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
            Mural mural = db.Mural.Find(id);
            if (mural == null)
            {
                return HttpNotFound();
            }
            return View(mural);
        }


        // POST: Mural/Edit/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mural"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Mural mural)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mural).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mural);
        }


        // GET: Mural/Delete/5
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
            var model = Get(id);

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }


        // POST: Mural/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mural mural = db.Mural.Find(id);
            db.Mural.Remove(mural);
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
