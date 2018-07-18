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
    public class EspecialidadesController : ApiController
    {
        private MedicalManagementDbContext db = new MedicalManagementDbContext();

        // GET: api/Especialidades
        public IQueryable<Especialidade> GetEspecialidade()
        {
            return db.Especialidade;
        }

        // GET: api/Especialidades/5
        [ResponseType(typeof(Especialidade))]
        public async Task<IHttpActionResult> GetEspecialidade(int id)
        {
            Especialidade especialidade = await db.Especialidade.FindAsync(id);
            if (especialidade == null)
            {
                return NotFound();
            }

            return Ok(especialidade);
        }

        // PUT: api/Especialidades/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEspecialidade(int id, Especialidade especialidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != especialidade.EspecialidadeId)
            {
                return BadRequest();
            }

            db.Entry(especialidade).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspecialidadeExists(id))
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

        // POST: api/Especialidades
        [ResponseType(typeof(Especialidade))]
        public async Task<IHttpActionResult> PostEspecialidade(Especialidade especialidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Especialidade.Add(especialidade);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = especialidade.EspecialidadeId }, especialidade);
        }

        // DELETE: api/Especialidades/5
        [ResponseType(typeof(Especialidade))]
        public async Task<IHttpActionResult> DeleteEspecialidade(int id)
        {
            Especialidade especialidade = await db.Especialidade.FindAsync(id);
            if (especialidade == null)
            {
                return NotFound();
            }

            db.Especialidade.Remove(especialidade);
            await db.SaveChangesAsync();

            return Ok(especialidade);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EspecialidadeExists(int id)
        {
            return db.Especialidade.Count(e => e.EspecialidadeId == id) > 0;
        }
    }
}