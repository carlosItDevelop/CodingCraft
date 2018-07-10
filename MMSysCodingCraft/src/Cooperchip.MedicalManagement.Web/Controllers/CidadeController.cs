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
    /// Controlador Web API de Cidade
    /// </summary>
    [System.Web.Http.RoutePrefix("api/v1/evm")]
    public class CidadeController : ApiController
    {
        private MedicalManagementDbContext db = new MedicalManagementDbContext();


        // ---/ Obter auxiliares --------------------



        /// <summary>
        /// Obter UFs
        /// </summary>
        /// <remarks>Obtem uma lista com as descrições de todas as UFs</remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("ObterUfs")]
        public IQueryable<Uf> GetUfs()
        {
            return db.Uf;
        }



        // ---/ --------------------------------------


        /// <summary>
        /// Obtem os Cidades
        /// </summary>
        /// <remarks>Obtem uma lista com todos os Cidades</remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("ObterCidades")]
        public IQueryable<Cidade> GetCidade()
        {
            return db.Cidade;
        }


        /// <summary>
        /// Obtem um Cidade por Id
        /// </summary>
        /// <remarks>Obtem um objeto Cidade, através do parâmetro Id</remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("ObterCidadePorId")]
        public HttpResponseMessage GetCidade(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Cidade cidade = db.Cidade.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, cidade);
        }

        /// <summary>
        /// Alterar um Cidade
        /// </summary>
        /// <remarks>Alterar um Cidade, através de um objeto passado e seu Id</remarks>
        /// <returns></returns>
        [HttpPut]
        [Route("AlterarCidade")]
        public HttpResponseMessage PutCidade(Cidade cidade)
        {
            if (cidade == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            db.Entry(cidade).State = EntityState.Modified;
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, cidade);
        }


        /// <summary>
        /// Adiciona um Cidade
        /// </summary>
        /// <remarks>Adiciona um Cidade, através de um objeto passado SEM seu Id</remarks>
        /// <returns></returns>
        [HttpPost]
        [Route("AdicionarCidade")]
        public HttpResponseMessage PostCidade(Cidade cidade)
        {
            if (cidade == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            db.Cidade.Add(cidade);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, cidade);
        }


        /// <summary>
        /// Exclui um Cidade
        /// </summary>
        /// <remarks>Exclui um Cidade, através de de seu Id</remarks>
        /// <returns></returns>
        [HttpDelete]
        [Route("ExcluirCidade")]
        public HttpResponseMessage DeleteCidade(int id)
        {
            if (id <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Cidade cidade = db.Cidade.Find(id);
            db.Cidade.Remove(cidade);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, cidade);
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
