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
    /// API de Leitos
    /// </summary>
    /// <remarks>APIs de Leitos do Sistema MedicalManagement-Sys</remarks>
    [System.Web.Http.RoutePrefix("api/v1/evm")]
    public class LeitoController : ApiController
    {
        private readonly MedicalManagementDbContext _db = new MedicalManagementDbContext();


        /// <summary>
        /// Obter Leitos
        /// </summary>
        /// <remarks>Obter todos os Leitos cadastrados</remarks>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetLeitos")]
        public IQueryable<Leito> ObterLeito()
        {
            return _db.Leito;
        }


        /// <summary>
        /// Obter Paciente Específico
        /// </summary>
        /// <remarks>Obter um Leito Específico, através do seu Id</remarks>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetLeitoPorId/{id:int}")]
        public HttpResponseMessage ObeterLeitoPorId(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Leito leito = _db.Leito.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, leito);
        }


        /// <summary>
        /// Alterar Leito
        /// </summary>
        /// <remarks>Alteração de um Leito específico, passando o objeto inteiro</remarks>
        /// <returns></returns>
        [HttpPut]
        [Route("PutLeito")]
        public HttpResponseMessage AlterarLeito(Leito leito)
        {
            if (leito == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Entry(leito).State = EntityState.Modified;
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, leito);
        }

        /// <summary>
        /// Adicionar Leito
        /// </summary>
        /// <remarks>Adicionar um Leito específico, passando o objeto inteiro SEM seu Id</remarks>
        /// <returns></returns>
        [HttpPost]
        [Route("PostLeito")]
        public HttpResponseMessage IncluirLeito(Leito leito)
        {
            if (leito == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Leito.Add(leito);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, leito);
        }


        /// <summary>
        /// Excluir Leito
        /// </summary>
        /// <remarks>Excluir um Leito específico através de seu Id</remarks>
        /// <returns></returns>
        [HttpDelete]
        [Route("DelLeito/{id:int}")]
        public HttpResponseMessage ExcluirLeito(int id)
        {
            if (id <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Leito leito = _db.Leito.Find(id);
            _db.Leito.Remove(leito);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, leito);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
