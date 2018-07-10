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
    public class EnderecoController : Controller
    {
        private MedicalManagementDbContext db = new MedicalManagementDbContext();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            var endereco = db.Endereco
                .Include(e => e.Bairro)
                .Include(e => e.Cidade)
                .Include(e => e.Paciente)
                .Include(e => e.Uf);
            return View(await endereco.ToListAsync());

            //return View(await db.Endereco.ToListAsync());

        }

        // GET: Endereco/Details/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = await db.Endereco.FindAsync(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // GET: Endereco/Create
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            ViewBag.IdBairro = new SelectList(db.Bairro, "BairroId", "Descricao");
            ViewBag.IdCidade = new SelectList(db.Cidade, "CidadeId", "Descricao");
            ViewBag.PacienteId = new SelectList(db.Paciente, "PacienteId", "Nome");
            ViewBag.IdUf = new SelectList(db.Uf, "UfId", "Sigla");
            return View();
        }

        // POST: Endereco/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.Endereco.Add(endereco);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdBairro = new SelectList(db.Bairro, "BairroId", "Descricao", endereco.IdBairro);
            ViewBag.IdCidade = new SelectList(db.Cidade, "CidadeId", "Descricao", endereco.IdCidade);
            ViewBag.PacienteId = new SelectList(db.Paciente, "PacienteId", "Nome", endereco.PacienteId);
            ViewBag.IdUf = new SelectList(db.Uf, "UfId", "Sigla", endereco.IdUf);
            return View(endereco);
        }

        // GET: Endereco/Edit/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = await db.Endereco.FindAsync(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdBairro = new SelectList(db.Bairro, "BairroId", "Descricao", endereco.IdBairro);
            ViewBag.IdCidade = new SelectList(db.Cidade, "CidadeId", "Descricao", endereco.IdCidade);
            ViewBag.PacienteId = new SelectList(db.Paciente, "PacienteId", "Nome", endereco.PacienteId);
            ViewBag.IdUf = new SelectList(db.Uf, "UfId", "Sigla", endereco.IdUf);
            return View(endereco);
        }

        // POST: Endereco/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(endereco).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdBairro = new SelectList(db.Bairro, "BairroId", "Descricao", endereco.IdBairro);
            ViewBag.IdCidade = new SelectList(db.Cidade, "CidadeId", "Descricao", endereco.IdCidade);
            ViewBag.PacienteId = new SelectList(db.Paciente, "PacienteId", "Nome", endereco.PacienteId);
            ViewBag.IdUf = new SelectList(db.Uf, "UfId", "Sigla", endereco.IdUf);
            return View(endereco);
        }

        // GET: Endereco/Delete/5
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
            Endereco endereco = await db.Endereco.FindAsync(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // POST: Endereco/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Endereco endereco = await db.Endereco.FindAsync(id);
            db.Endereco.Remove(endereco);
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
