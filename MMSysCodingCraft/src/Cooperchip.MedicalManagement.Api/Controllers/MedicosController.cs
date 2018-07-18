using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Cooperchip.MedicalManagement.Domain.Entidade;
using Cooperchip.MedicalManagement.Infra.Data;

namespace Cooperchip.MedicalManagement.Api.Controllers
{
    public class MedicosController : ApiController
    {
        private MedicalManagementDbContext db = new MedicalManagementDbContext();

        // GET: api/Medicos
        public async Task<List<Medico>> GetMedico()
        {
            var medicos = await db.Medico
                     .Include(m => m.PessoaFisica)
                     .ToListAsync();

            return medicos.Select(m => new Medico {
                MedicoId = m.MedicoId,
                Especialidade = m.Especialidade,
                PessoaFisica = m.PessoaFisica,
                Crm = m.Crm
            }).ToList();
        }

        // GET: api/Medicos/5
        [ResponseType(typeof(Medico))]
        public async Task<IHttpActionResult> GetMedico(Guid id)
        {
            Medico medico = await db.Medico
                                    .Include(m => m.PessoaFisica)
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(m => m.MedicoId == id);
            if (medico == null)
            {
                return NotFound();
            }

            return Ok(medico);
        }

        // PUT: api/Medicos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMedico(Guid id, Medico medico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medico.MedicoId)
            {
                return BadRequest();
            }

            db.Entry(medico).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Medicos
        [ResponseType(typeof(Medico))]
        public async Task<IHttpActionResult> PostMedico(Medico medico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Medico.Add(medico);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MedicoExists(medico.MedicoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = medico.MedicoId }, medico);
        }

        // DELETE: api/Medicos/5
        [ResponseType(typeof(Medico))]
        public async Task<IHttpActionResult> DeleteMedico(Guid id)
        {
            Medico medico = await db.Medico.FindAsync(id);
            if (medico == null)
            {
                return NotFound();
            }

            db.Medico.Remove(medico);
            await db.SaveChangesAsync();

            return Ok(medico);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MedicoExists(Guid id)
        {
            return db.Medico.Count(e => e.MedicoId == id) > 0;
        }
    }
}