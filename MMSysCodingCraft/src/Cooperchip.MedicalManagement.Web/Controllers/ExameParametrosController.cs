using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Cooperchip.MedicalManagement.Infra.Data;
using Cooperchip.MedicalManagement.Domain.Entidade;

namespace Cooperchip.MedicalManagement.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ExameParametrosController : Controller
    {
        private MedicalManagementDbContext db = new MedicalManagementDbContext();

        // GET: ExameParametros
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            return View(await db.ExameParametros.ToListAsync());
        }

        // GET: ExameParametros/Details/5
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
            ExameParametros exameParametros = await db.ExameParametros.FindAsync(id);
            if (exameParametros == null)
            {
                return HttpNotFound();
            }
            return View(exameParametros);
        }

        // GET: ExameParametros/Create
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExameParametros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exameParametros"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ExameParametrosId,Exame,Minimo,Maximo")] ExameParametros exameParametros)
        {
            if (ModelState.IsValid)
            {
                //exameParametros.ExameParametrosId = Guid.NewGuid();
                db.ExameParametros.Add(exameParametros);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(exameParametros);
        }

        // GET: ExameParametros/Edit/5
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
            ExameParametros exameParametros = await db.ExameParametros.FindAsync(id);
            if (exameParametros == null)
            {
                return HttpNotFound();
            }
            return View(exameParametros);
        }

        // POST: ExameParametros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exameParametros"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ExameParametrosId,Exame,Minimo,Maximo")] ExameParametros exameParametros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exameParametros).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(exameParametros);
        }

        // GET: ExameParametros/Delete/5
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
            ExameParametros exameParametros = await db.ExameParametros.FindAsync(id);
            if (exameParametros == null)
            {
                return HttpNotFound();
            }
            return View(exameParametros);
        }

        // POST: ExameParametros/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            ExameParametros exameParametros = await db.ExameParametros.FindAsync(id);
            db.ExameParametros.Remove(exameParametros);
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
