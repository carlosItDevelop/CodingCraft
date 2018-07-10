using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Cooperchip.MedicalManagement.Domain.Entidade;
using Cooperchip.MedicalManagement.Infra.Data;
using AspNetInterop.UI.MVC5.Permissions;

namespace Cooperchip.MedicalManagement.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ContraIndicacaoController : Controller
    {
        private MedicalManagementDbContext db = new MedicalManagementDbContext();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: ContraIndicacao
        [ClaimsAcesso("ContraIndicacao", "Listar")]
        public async Task<ActionResult> Index()
        {
            var contraIndicacao = db.ContraIndicacao.Include(c => c.Generico);      
            return View(await contraIndicacao.ToListAsync());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: ContraIndicacao/Details/5
        [ClaimsAcesso("ContraIndicacao", "Detalhes")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContraIndicacao contraIndicacao = await db.ContraIndicacao.FindAsync(id);
            if (contraIndicacao == null)
            {
                return HttpNotFound();
            }
            return View(contraIndicacao);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: ContraIndicacao/Create
        [ClaimsAcesso("ContraIndicacao", "Adicionar")]
        public ActionResult Create()
        {
            ViewBag.IdGenerico = new SelectList(db.Generico, "GenericoId", "Descricao");
            return View();
        }

        // POST: ContraIndicacao/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contraIndicacao"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ClaimsAcesso("ContraIndicacao", "Adicionar")]
        public async Task<ActionResult> Create(ContraIndicacao contraIndicacao)
        {
            if (ModelState.IsValid)
            {
                db.ContraIndicacao.Add(contraIndicacao);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdGenerico = new SelectList(db.Generico, "GenericoId", "Descricao", contraIndicacao.IdGenerico);
            return View(contraIndicacao);
        }

        // GET: ContraIndicacao/Edit/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ClaimsAcesso("ContraIndicacao", "Editar")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContraIndicacao contraIndicacao = await db.ContraIndicacao.FindAsync(id);
            if (contraIndicacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdGenerico = new SelectList(db.Generico, "GenericoId", "Descricao", contraIndicacao.IdGenerico);
            return View(contraIndicacao);
        }

        // POST: ContraIndicacao/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contraIndicacao"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ClaimsAcesso("ContraIndicacao", "Editar")]
        public async Task<ActionResult> Edit(ContraIndicacao contraIndicacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contraIndicacao).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdGenerico = new SelectList(db.Generico, "GenericoId", "Descricao", contraIndicacao.IdGenerico);
            return View(contraIndicacao);
        }

        // GET: ContraIndicacao/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ClaimsAcesso("ContraIndicacao", "Excluir")]         
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContraIndicacao contraIndicacao = await db.ContraIndicacao.FindAsync(id);
            if (contraIndicacao == null)
            {
                return HttpNotFound();
            }
            return View(contraIndicacao);
        }

        // POST: ContraIndicacao/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ClaimsAcesso("ContraIndicacao", "Excluir")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ContraIndicacao contraIndicacao = await db.ContraIndicacao.FindAsync(id);
            db.ContraIndicacao.Remove(contraIndicacao);
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
