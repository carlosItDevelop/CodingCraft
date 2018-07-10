using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Cooperchip.MedicalManagement.Domain.Entidade;
using Cooperchip.MedicalManagement.Infra.Data;

namespace Cooperchip.MedicalManagement.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class TipoDePrecaucaoController : Controller
    {
        private MedicalManagementDbContext db = new MedicalManagementDbContext();

        // GET: TipoDePrecaucao
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            return View(await db.TipoDePrecaucao.ToListAsync());
        }



        // GET: TipoDePrecaucao/Create
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
        /// <param name="tipoDePrecaucao"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Descricao")] TipoDePrecaucao tipoDePrecaucao)
        {
            if (ModelState.IsValid)
            {
                db.TipoDePrecaucao.Add(tipoDePrecaucao);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipoDePrecaucao);
        }



        // GET: TipoDePrecaucao/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDePrecaucao tipoDePrecaucao = await db.TipoDePrecaucao.FindAsync(id);
            if (tipoDePrecaucao == null)
            {
                return HttpNotFound();
            }
            return View(tipoDePrecaucao);
        }

        // POST: TipoDePrecaucao/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TipoDePrecaucao tipoDePrecaucao = await db.TipoDePrecaucao.FindAsync(id);
            db.TipoDePrecaucao.Remove(tipoDePrecaucao);
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
