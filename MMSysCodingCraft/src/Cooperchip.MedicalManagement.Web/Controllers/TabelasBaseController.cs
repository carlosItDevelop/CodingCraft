using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Cooperchip.MedicalManagement.Domain.Entidade;
using Cooperchip.MedicalManagement.Infra.Data;


namespace Cooperchip.MedicalManagement.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class TabelasBaseController : Controller
    {
        private MedicalManagementDbContext db = new MedicalManagementDbContext();

        // GET: TabelasBase
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(db.TabelasBase.ToList());
        }

        // GET: TabelasBase/Details/5
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
            TabelasBase tabelasBase = db.TabelasBase.Find(id);
            if (tabelasBase == null)
            {
                return HttpNotFound();
            }
            return View(tabelasBase);
        }

        // GET: TabelasBase/Create
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        // POST: TabelasBase/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tabelasBase"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TabelasBase tabelasBase)
        {
            if (ModelState.IsValid)
            {
                db.TabelasBase.Add(tabelasBase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tabelasBase);
        }

        // GET: TabelasBase/Edit/5
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
            TabelasBase tabelasBase = db.TabelasBase.Find(id);
            if (tabelasBase == null)
            {
                return HttpNotFound();
            }
            return View(tabelasBase);
        }

        // POST: TabelasBase/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tabelasBase"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TabelasBaseId,Nome,Descricao,Action,Controller,Ativa")] TabelasBase tabelasBase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tabelasBase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tabelasBase);
        }

        // GET: TabelasBase/Delete/5
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
            TabelasBase tabelasBase = db.TabelasBase.Find(id);
            if (tabelasBase == null)
            {
                return HttpNotFound();
            }
            return View(tabelasBase);
        }

        // POST: TabelasBase/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TabelasBase tabelasBase = db.TabelasBase.Find(id);
            db.TabelasBase.Remove(tabelasBase);
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
