using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
    public class ResultadoExameController : Controller
    {
        private MedicalManagementDbContext db = new MedicalManagementDbContext();

        // GET: ResultadoExame
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            var resultadoExame = db.ResultadoExame.Include(r => r.ExameParametros).Include(r => r.Medico);
            return View(await resultadoExame.ToListAsync());
        }

        // GET: ResultadoExame/Details/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResultadoExame resultadoExame = await db.ResultadoExame.FindAsync(id);
            if (resultadoExame == null)
            {
                return HttpNotFound();
            }
            return View(resultadoExame);
        }

        // GET: ResultadoExame/Create
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            ViewBag.IdExameParametros = new SelectList(db.ExameParametros, "ExameParametrosId", "Exame");
            ViewBag.MedicoId = new SelectList(db.Medico, "MedicoId", "Nome");
            return View();
        }

        // POST: ResultadoExame/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resultadoExame"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ResultadoExame resultadoExame)
        {
            if (ModelState.IsValid)
            {
                //resultadoExame.ResultadoExameId = Guid.NewGuid();
                db.ResultadoExame.Add(resultadoExame);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdExameParametros = new SelectList(db.ExameParametros, "ExameParametrosId", "Exame", resultadoExame.IdExameParametros);
            ViewBag.MedicoId = new SelectList(db.Medico, "MedicoId", "Nome", resultadoExame.MedicoId);
            return View(resultadoExame);
        }

        // GET: ResultadoExame/Edit/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResultadoExame resultadoExame = await db.ResultadoExame.FindAsync(id);
            if (resultadoExame == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdExameParametros = new SelectList(db.ExameParametros, "ExameParametrosId", "Exame", resultadoExame.IdExameParametros);
            ViewBag.MedicoId = new SelectList(db.Medico, "MedicoId", "Nome", resultadoExame.MedicoId);
            return View(resultadoExame);
        }

        // POST: ResultadoExame/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resultadoExame"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ResultadoExame resultadoExame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resultadoExame).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdExameParametros = new SelectList(db.ExameParametros, "ExameParametrosId", "Exame", resultadoExame.IdExameParametros);
            ViewBag.MedicoId = new SelectList(db.Medico, "MedicoId", "Nome", resultadoExame.MedicoId);
            return View(resultadoExame);
        }

        // GET: ResultadoExame/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResultadoExame resultadoExame = await db.ResultadoExame.FindAsync(id);
            if (resultadoExame == null)
            {
                return HttpNotFound();
            }
            return View(resultadoExame);
        }

        // POST: ResultadoExame/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            ResultadoExame resultadoExame = await db.ResultadoExame.FindAsync(id);
            db.ResultadoExame.Remove(resultadoExame);
            await db.SaveChangesAsync();
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
