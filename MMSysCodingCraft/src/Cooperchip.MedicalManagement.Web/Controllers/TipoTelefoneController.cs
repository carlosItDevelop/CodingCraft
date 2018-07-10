using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Cooperchip.MedicalManagement.Infra.Data;
using AspNetInterop.UI.MVC5.Permissions;
using Cooperchip.MedicalManagement.Domain.Entidade;

namespace Cooperchip.MedicalManagement.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class TipoTelefoneController : Controller
    {
        private MedicalManagementDbContext db = new MedicalManagementDbContext();

        // GET: TipoTelefone
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ClaimsAcesso("TipoTelefone", "Listar")]
        public ActionResult Index()
        {
            return View(db.TipoTelefone.ToList());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: TipoTelefone/Details/5
        [ClaimsAcesso("TipoTelefone", "Detalhes")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTelefone tipoTelefone = db.TipoTelefone.Find(id);
            if (tipoTelefone == null)
            {
                return HttpNotFound();
            }
            return View(tipoTelefone);
        }

        // GET: TipoTelefone/Create
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ClaimsAcesso("TipoTelefone", "Adicionar")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoTelefone/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoTelefone"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ClaimsAcesso("TipoTelefone", "Adicionar")]
        public ActionResult Create(TipoTelefone tipoTelefone)
        {
            if (ModelState.IsValid)
            {
                db.TipoTelefone.Add(tipoTelefone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoTelefone);
        }

        // GET: TipoTelefone/Edit/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ClaimsAcesso("TipoTelefone", "Editar")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTelefone tipoTelefone = db.TipoTelefone.Find(id);
            if (tipoTelefone == null)
            {
                return HttpNotFound();
            }
            return View(tipoTelefone);
        }

        // POST: TipoTelefone/Edit/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoTelefone"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ClaimsAcesso("TipoTelefone", "Editar")]
        public ActionResult Edit(TipoTelefone tipoTelefone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoTelefone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoTelefone);
        }

        // GET: TipoTelefone/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ClaimsAcesso("TipoTelefone", "Excluir")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTelefone tipoTelefone = db.TipoTelefone.Find(id);
            if (tipoTelefone == null)
            {
                return HttpNotFound();
            }
            return View(tipoTelefone);
        }

        // POST: TipoTelefone/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ClaimsAcesso("TipoTelefone", "Excluir")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoTelefone tipoTelefone = db.TipoTelefone.Find(id);
            db.TipoTelefone.Remove(tipoTelefone);
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
