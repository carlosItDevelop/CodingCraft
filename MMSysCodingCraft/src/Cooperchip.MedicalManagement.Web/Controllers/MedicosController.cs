﻿using System;
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
using Cooperchip.MedicalManagement.Web.ViewModel;
using System.Transactions;

namespace Cooperchip.MedicalManagement.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class MedicosController : Controller
    {
        private MedicalManagementDbContext db = new MedicalManagementDbContext();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            var medico = db.Medico.Include(m => m.Especialidade).Include(m => m.PessoaFisica);
            return View(await medico.ToListAsync());
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
            Medico medico = await db.Medico.FindAsync(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            ViewBag.EspecialidadeId = new SelectList(db.Especialidade, "EspecialidadeId", "Descricao");
            //ViewBag.MedicoId = new SelectList(db.PessoaFisica, "PessoaId", "NomeOuRazaoSocial");
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="medicoViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MedicoViewModel medicoViewModel)
        {

            medicoViewModel.MedicoId = Guid.NewGuid();
            ModelState[nameof(medicoViewModel.MedicoId)].Errors.Clear();

            if (ModelState.IsValid)
            {

                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {


                    var pfisica = (PessoaFisica)medicoViewModel;
                    db.PessoaFisica.Add(pfisica);
                    await db.SaveChangesAsync();


                    var medico = (Medico)medicoViewModel;
                    db.Medico.Add(medico);
                    await db.SaveChangesAsync();


                    scope.Complete();
                }

                return RedirectToAction("Index");
            }

            ViewBag.EspecialidadeId = new SelectList(db.Especialidade, "EspecialidadeId", "Descricao", medicoViewModel.EspecialidadeId);
            //ViewBag.MedicoId = new SelectList(db.PessoaFisica, "PessoaId", "NomeOuRazaoSocial", medicoViewModel.MedicoId);
            return View(medicoViewModel);
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
            Medico medico = await db.Medico.FindAsync(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            ViewBag.EspecialidadeId = new SelectList(db.Especialidade, "EspecialidadeId", "Descricao", medico.EspecialidadeId);
            //ViewBag.MedicoId = new SelectList(db.PessoaFisica, "PessoaId", "NomeOuRazaoSocial", medico.MedicoId);
            return View(medico);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="medico"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MedicoId,Nome,Crm,EspecialidadeId")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EspecialidadeId = new SelectList(db.Especialidade, "EspecialidadeId", "Descricao", medico.EspecialidadeId);
            //ViewBag.MedicoId = new SelectList(db.PessoaFisica, "PessoaId", "NomeOuRazaoSocial", medico.MedicoId);
            return View(medico);
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
            Medico medico = await db.Medico.FindAsync(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
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
            Medico medico = await db.Medico.FindAsync(id);
            db.Medico.Remove(medico);
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