using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cooperchip.MedicalManagement.Domain.Entidade;
using Cooperchip.MedicalManagement.Infra.Data;

namespace Cooperchip.MedicalManagement.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [System.Web.Http.RoutePrefix("api/v1/evm")]
    public class CidController : ApiController
    {
        private MedicalManagementDbContext db = new MedicalManagementDbContext();

        /// <summary>
        /// Obtem todos as doenças registradas no CID
        /// </summary>
        /// <remarks>Obtem todos as doenças registradas no CID</remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("ObterCidAdaptadas")]
        public IQueryable<CidAdaptada> GetCidAdaptada()
        {
            return db.CidAdaptada;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ObterCidAdaptadaPorId")]
        public HttpResponseMessage GetCidAdaptada(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            CidAdaptada cidadaptada = db.CidAdaptada.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, cidadaptada);
        }

        //[HttpPut]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cidadaptada"></param>
        /// <returns></returns>
        [Route("AlterarCidAdaptada")]
        public HttpResponseMessage PutCidAdaptada(CidAdaptada cidadaptada)
        {
            if (cidadaptada == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            db.Entry(cidadaptada).State = EntityState.Modified;
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, cidadaptada);
        }

        //[HttpPost]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cidadaptada"></param>
        /// <returns></returns>
        [Route("AdicionarCidAdaptada")]
        public HttpResponseMessage PostCidAdaptada(CidAdaptada cidadaptada)
        {
            if (cidadaptada == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            db.CidAdaptada.Add(cidadaptada);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, cidadaptada);
        }

        //[HttpDelete]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("ExcluirCidAdaptada")]
        public HttpResponseMessage DeleteCidAdaptada(int id)
        {
            if (id <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            CidAdaptada cidadaptada = db.CidAdaptada.Find(id);
            db.CidAdaptada.Remove(cidadaptada);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, cidadaptada);
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