using System.Data.Entity;
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
    /// Controller de gestão de Uf
    /// </summary>
    [RoutePrefix("api/v1/evm")]
    public class UfController : ApiController
    {


        private MedicalManagementDbContext _db = new MedicalManagementDbContext();

        /// <summary>
        /// Obtem uma coleção de Uf
        /// </summary>
        /// <remarks>Obtem uma coleção completa com todos os Ufs</remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("ObterUf")]
        [ResponseType(typeof(Uf))]
        public IQueryable<Uf> GetUf()
        {
            return _db.Uf;
        }

        /// <summary>
        /// Obtem Uf por Id
        /// </summary>
        /// <remarks>Obtem um objeto Uf, através do parâmetro Id</remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ObterUfPorId")]
        [ResponseType(typeof(Uf))]
        public HttpResponseMessage GetUf(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Uf uf = _db.Uf.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, uf);
        }

        /// <summary>
        /// Altera um objeto Uf
        /// </summary>
        /// <remarks>Altera um objeto Uf, passando o obteto SEM seu Id</remarks>
        /// <param name="uf"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("AlterarUf")]
        [ResponseType(typeof(Uf))]
        public HttpResponseMessage PutUf(Uf uf)
        {
            if (uf == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Entry(uf).State = EntityState.Modified;
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, uf);
        }

        /// <summary>
        /// Adição de Uf
        /// </summary>
        /// <remarks>Cadastra um objeto Uf passando sua Descrição apenas</remarks>
        /// <param name="uf"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AdicionarUf")]
        [ResponseType(typeof(Uf))]
        public HttpResponseMessage PostUf(Uf uf)
        {
            if (uf == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Uf.Add(uf);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, uf);
        }

        /// <summary>
        /// Exclusão de Uf
        /// </summary>
        /// <remarks>Exclusão de Uf através da passagem do parâmetro Id</remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("ExcluirUf")]
        [ResponseType(typeof(Uf))]
        public HttpResponseMessage DeleteUf(int id)
        {
            if (id <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Uf uf = _db.Uf.Find(id);
            _db.Uf.Remove(uf);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, uf);
        }

        /// <summary>
        /// Realisa um dispose na entidade db
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
