using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cooperchip.MedicalManagement.Domain.Entidade;
using Cooperchip.MedicalManagement.Infra.Data;

namespace Cooperchip.MedicalManagement.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class PessoasJuridicasController : Controller
    {
        private MedicalManagementDbContext db = new MedicalManagementDbContext();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            return View(await db.PessoaJuridica.ToListAsync());
        }

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
            PessoaJuridica pessoaJuridica = await db.PessoaJuridica.FindAsync(id);
            if (pessoaJuridica == null)
            {
                return HttpNotFound();
            }
            return View(pessoaJuridica);
        }

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
        /// <param name="pessoaJuridica"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PessoaId,NomeOuRazaoSocial,DataNascimentoOuFundacao,Email,CpfOrCnpj,Ativo,DataUltimaModificacao,UsuarioUltimaModificacao,DataInclusao,UsuarioInclusao")] PessoaJuridica pessoaJuridica)
        {
            if (ModelState.IsValid)
            {
                pessoaJuridica.PessoaId = Guid.NewGuid();
                db.PessoaJuridica.Add(pessoaJuridica);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pessoaJuridica);
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
            PessoaJuridica pessoaJuridica = await db.PessoaJuridica.FindAsync(id);
            if (pessoaJuridica == null)
            {
                return HttpNotFound();
            }
            return View(pessoaJuridica);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pessoaJuridica"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PessoaId,NomeOuRazaoSocial,DataNascimentoOuFundacao,Email,CpfOrCnpj,Ativo,DataUltimaModificacao,UsuarioUltimaModificacao,DataInclusao,UsuarioInclusao")] PessoaJuridica pessoaJuridica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoaJuridica).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pessoaJuridica);
        }

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
            PessoaJuridica pessoaJuridica = await db.PessoaJuridica.FindAsync(id);
            if (pessoaJuridica == null)
            {
                return HttpNotFound();
            }
            return View(pessoaJuridica);
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
            PessoaJuridica pessoaJuridica = await db.PessoaJuridica.FindAsync(id);
            db.PessoaJuridica.Remove(pessoaJuridica);
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
