using System;
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
    public class PessoasFisicasController : Controller
    {
        private MedicalManagementDbContext db = new MedicalManagementDbContext();

        // GET: PessoasFisicas
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            var PessoaFisica = db.PessoaFisica.Include(p => p.Medico).Include(p => p.Paciente);
            return View(await PessoaFisica.ToListAsync());
        }

        // GET: PessoasFisicas/Details/5
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
            PessoaFisica pessoaFisica = await db.PessoaFisica.FindAsync(id);
            if (pessoaFisica == null)
            {
                return HttpNotFound();
            }
            return View(pessoaFisica);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            //ViewBag.PessoaId = new SelectList(db.Medico, "MedicoId", "Nome");
            //ViewBag.PessoaId = new SelectList(db.Paciente, "PacienteId", "Complicacao");
            return View();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pessoaFisica"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PessoaId,NomeOuRazaoSocial,DataNascimentoOuFundacao,Email,CpfOrCnpj,Ativo,DataUltimaModificacao,UsuarioUltimaModificacao,DataInclusao,UsuarioInclusao,Rg,OrgaoEmissorRg,DataEmissaoRg,EstadoCivil,Sexo")] PessoaFisica pessoaFisica)
        {
            if (ModelState.IsValid)
            {
                pessoaFisica.PessoaId = Guid.NewGuid();
                db.PessoaFisica.Add(pessoaFisica);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            //ViewBag.PessoaId = new SelectList(db.Medico, "MedicoId", "Nome", pessoaFisica.PessoaId);
            //ViewBag.PessoaId = new SelectList(db.Paciente, "PacienteId", "Complicacao", pessoaFisica.PessoaId);
            return View(pessoaFisica);
        }


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
            PessoaFisica pessoaFisica = await db.PessoaFisica.FindAsync(id);
            if (pessoaFisica == null)
            {
                return HttpNotFound();
            }
            //ViewBag.PessoaId = new SelectList(db.Medico, "MedicoId", "Nome", pessoaFisica.PessoaId);
            //ViewBag.PessoaId = new SelectList(db.Paciente, "PacienteId", "Complicacao", pessoaFisica.PessoaId);
            return View(pessoaFisica);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pessoaFisica"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PessoaId,NomeOuRazaoSocial,DataNascimentoOuFundacao,Email,CpfOrCnpj,Ativo,DataUltimaModificacao,UsuarioUltimaModificacao,DataInclusao,UsuarioInclusao,Rg,OrgaoEmissorRg,DataEmissaoRg,EstadoCivil,Sexo")] PessoaFisica pessoaFisica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoaFisica).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            //ViewBag.PessoaId = new SelectList(db.Medico, "MedicoId", "Nome", pessoaFisica.PessoaId);
            //ViewBag.PessoaId = new SelectList(db.Paciente, "PacienteId", "Complicacao", pessoaFisica.PessoaId);
            return View(pessoaFisica);
        }

        // GET: PessoasFisicas/Delete/5
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
            PessoaFisica pessoaFisica = await db.PessoaFisica.FindAsync(id);
            if (pessoaFisica == null)
            {
                return HttpNotFound();
            }
            return View(pessoaFisica);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            PessoaFisica pessoaFisica = await db.PessoaFisica.FindAsync(id);
            db.PessoaFisica.Remove(pessoaFisica);
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
