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
    /// Controlador Web API de Bairro
    /// </summary>
    [System.Web.Http.RoutePrefix("api/v1/evm")]
    public class BairroController : ApiController
    {
        private MedicalManagementDbContext db = new MedicalManagementDbContext();


        // ---/ Obter auxiliares --------------------



        /// <summary>
        /// Obter Cidades
        /// </summary>
        /// <remarks>Obtem uma lista com as descrições de todas as Cidades</remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("ObterCidadeParaBairro")]
        public IQueryable<Cidade> GetCidades()
        {
            return db.Cidade;
        }



        // ---/ --------------------------------------


        /// <summary>
        /// Obtem os Bairros
        /// </summary>
        /// <remarks>Obtem uma lista com todos os Bairros</remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("ObterBairros")]
        public IQueryable<Bairro> GetBairro()
        {
            return db.Bairro;
        }


        /// <summary>
        /// Obtem um Bairro por Id
        /// </summary>
        /// <remarks>Obtem um objeto Bairro, através do parâmetro Id</remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("ObterBairroPorId")]
        public HttpResponseMessage GetBairro(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Bairro bairro = db.Bairro.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, bairro);
        }

        /// <summary>
        /// Alterar um Bairro
        /// </summary>
        /// <remarks>Alterar um Bairro, através de um objeto passado e seu Id</remarks>
        /// <returns></returns>
        [HttpPut]
        [Route("AlterarBairro")]
        public HttpResponseMessage PutBairro(Bairro bairro)
        {
            if (bairro == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            db.Entry(bairro).State = EntityState.Modified;
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, bairro);
        }


        /// <summary>
        /// Adiciona um Bairro
        /// </summary>
        /// <remarks>Adiciona um Bairro, através de um objeto passado SEM seu Id</remarks>
        /// <returns></returns>
        [HttpPost]
        [Route("AdicionarBairro")]
        public HttpResponseMessage PostBairro(Bairro bairro)
        {
            if (bairro == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            db.Bairro.Add(bairro);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, bairro);
        }


        /// <summary>
        /// Exclui um Bairro
        /// </summary>
        /// <remarks>Exclui um Bairro, através de de seu Id</remarks>
        /// <returns></returns>
        [HttpDelete]
        [Route("ExcluirBairro")]
        public HttpResponseMessage DeleteBairro(int id)
        {
            if (id <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Bairro bairro = db.Bairro.Find(id);
            db.Bairro.Remove(bairro);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, bairro);
        }

        /// <summary>
        /// Poe no lixo a instancia de db
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
