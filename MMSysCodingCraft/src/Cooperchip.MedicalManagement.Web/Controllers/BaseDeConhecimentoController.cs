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
    /// Controller de gestão de BaseDeConhecimento
    /// </summary>
    [RoutePrefix("api/v1/evm")]
    public class BaseDeConhecimentoController : ApiController
    {


        private MedicalManagementDbContext _db = new MedicalManagementDbContext();

        /// <summary>
        /// Obtem uma coleção de BaseDeConhecimento
        /// </summary>
        /// <remarks>Obtem uma coleção completa com todos os BaseDeConhecimentos</remarks>
        /// <returns></returns>
        [Route("ObterBaseDeConhecimento")]
        public IQueryable<BaseDeConhecimento> GetBaseDeConhecimento()
        {
            return _db.BaseDeConhecimento;
        }

        /// <summary>
        /// Obtem BaseDeConhecimento por Id
        /// </summary>
        /// <remarks>Obtem um objeto BaseDeConhecimento, através do parâmetro Id</remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("ObterBaseDeConhecimentoPorId")]
        public HttpResponseMessage GetBaseDeConhecimento(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            BaseDeConhecimento baseDeConhecimento = _db.BaseDeConhecimento.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, baseDeConhecimento);
        }

        /// <summary>
        /// Altera um objeto BaseDeConhecimento
        /// </summary>
        /// <remarks>Altera um objeto BaseDeConhecimento, passando o obteto SEM seu Id</remarks>
        /// <param name="baseDeConhecimento"></param>
        /// <returns></returns>
        [Route("AlterarBaseDeConhecimento")]
        public HttpResponseMessage PutBaseDeConhecimento(BaseDeConhecimento baseDeConhecimento)
        {
            if (baseDeConhecimento == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Entry(baseDeConhecimento).State = EntityState.Modified;
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, baseDeConhecimento);
        }

        /// <summary>
        /// Adição de BaseDeConhecimento
        /// </summary>
        /// <remarks>Cadastra um objeto BaseDeConhecimento passando sua Descrição apenas</remarks>
        /// <param name="baseDeConhecimento"></param>
        /// <returns></returns>
        [Route("AdicionarBaseDeConhecimento")]
        public HttpResponseMessage PostBaseDeConhecimento(BaseDeConhecimento baseDeConhecimento)
        {
            if (baseDeConhecimento == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.BaseDeConhecimento.Add(baseDeConhecimento);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, baseDeConhecimento);
        }

        /// <summary>
        /// Exclusão de BaseDeConhecimento
        /// </summary>
        /// <remarks>Exclusão de BaseDeConhecimento através da passagem do parâmetro Id</remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("ExcluirBaseDeConhecimento")]
        [ResponseType(typeof(BaseDeConhecimento))]
        public HttpResponseMessage DeleteBaseDeConhecimento(int id)
        {
            if (id <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            BaseDeConhecimento baseDeConhecimento = _db.BaseDeConhecimento.Find(id);
            _db.BaseDeConhecimento.Remove(baseDeConhecimento);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, baseDeConhecimento);
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
