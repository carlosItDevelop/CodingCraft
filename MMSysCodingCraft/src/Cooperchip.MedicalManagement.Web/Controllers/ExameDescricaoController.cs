using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Cooperchip.MedicalManagement.Domain.Entidade;
using Cooperchip.MedicalManagement.Infra.Data;

namespace Cooperchip.MedicalManagement.Web.Controllers
{

    /// <summary>
    /// Controlador Web API de ExameDescrição
    /// </summary>
    [RoutePrefix("api/v1/evm")]
    public class ExameDescricaoController : ApiController
    {
        private MedicalManagementDbContext db = new MedicalManagementDbContext();


        /// <summary>
        /// Obtem os ExameDescriçãos
        /// </summary>
        /// <remarks>Obtem uma lista com todos os ExameDescriçãos</remarks>
        /// <returns></returns>
        [Route("ObterExameDescricaos")]
        public IQueryable<ExameDescricao> GetExameDescricao()
        {
            return db.ExameDescricao;
        }


        /// <summary>
        /// Obtem um ExameDescrição por Id
        /// </summary>
        /// <remarks>Obtem um objeto ExameDescrição, através do parâmetro Id</remarks>
        /// <returns></returns>
        [Route("ObterExameDescricaoPorId")]
        [ResponseType(typeof(ExameDescricao))]
        public HttpResponseMessage GetExameDescricao(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            ExameDescricao examedescricao = db.ExameDescricao.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, examedescricao);
        }

        /// <summary>
        /// Alterar um ExameDescrição
        /// </summary>
        /// <remarks>Alterar um ExameDescrição, através de um objeto passado e seu Id</remarks>
        /// <returns></returns>
        [HttpPut]
        [Route("AlterarExameDescricao")]
        [ResponseType(typeof(void))]
        public HttpResponseMessage PutExameDescricao(ExameDescricao examedescricao)
        {
            if (examedescricao == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            db.Entry(examedescricao).State = EntityState.Modified;
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, examedescricao);
        }


        /// <summary>
        /// Adiciona um ExameDescrição
        /// </summary>
        /// <remarks>Adiciona um ExameDescrição, através de um objeto passado SEM seu Id</remarks>
        /// <returns></returns>
        [HttpPost]
        [Route("AdicionarExameDescricao")]
        [ResponseType(typeof(ExameDescricao))]
        public HttpResponseMessage PostExameDescricao(ExameDescricao examedescricao)
        {
            if (examedescricao == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            db.ExameDescricao.Add(examedescricao);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, examedescricao);
        }

        /// <summary>
        /// Exclui um ExameDescrição
        /// </summary>
        /// <remarks>Exclui um ExameDescrição, através de de seu Id</remarks>
        /// <returns></returns>
        [HttpDelete]
        [Route("ExcluirExameDescricao")]
        public HttpResponseMessage DeleteExameDescricao(int id)
        {
            if (id <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            ExameDescricao examedescricao = db.ExameDescricao.Find(id);
            db.ExameDescricao.Remove(examedescricao);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, examedescricao);
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