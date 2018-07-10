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
    /// Controller de gestão de Convenio
    /// </summary>
    [RoutePrefix("api/v1/evm")]
    public class ConvenioController : ApiController
    {


        private MedicalManagementDbContext _db = new MedicalManagementDbContext();

        /// <summary>
        /// Obtem uma coleção de Convenio
        /// </summary>
        /// <remarks>Obtem uma coleção completa com todos os Convenios</remarks>
        /// <returns></returns>
        [Route("ObterConvenio")]
        public IQueryable<Convenio> GetConvenio()
        {
            return _db.Convenio;
        }

        /// <summary>
        /// Obtem Convenio por Id
        /// </summary>
        /// <remarks>Obtem um objeto Convenio, através do parâmetro Id</remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("ObterConvenioPorId")]
        public HttpResponseMessage GetConvenio(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Convenio convenio = _db.Convenio.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, convenio);
        }

        /// <summary>
        /// Altera um objeto Convenio
        /// </summary>
        /// <remarks>Altera um objeto Convenio, passando o obteto SEM seu Id</remarks>
        /// <param name="convenio"></param>
        /// <returns></returns>
        [Route("AlterarConvenio")]
        public HttpResponseMessage PutConvenio(Convenio convenio)
        {
            if (convenio == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Entry(convenio).State = EntityState.Modified;
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, convenio);
        }

        /// <summary>
        /// Adição de Convenio
        /// </summary>
        /// <remarks>Cadastra um objeto Convenio passando sua Descrição apenas</remarks>
        /// <param name="convenio"></param>
        /// <returns></returns>
        [Authorize(Roles="xpto")]  // Não está deixando gravar, basta capturar a mensagem no Ctrl
        [Route("AdicionarConvenio")]
        public HttpResponseMessage PostConvenio(Convenio convenio)
        {
            if (convenio == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Convenio.Add(convenio);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, convenio);
        }

        /// <summary>
        /// Exclusão de Convenio
        /// </summary>
        /// <remarks>Exclusão de Convenio através da passagem do parâmetro Id</remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("ExcluirConvenio")]
        [ResponseType(typeof(Convenio))]
        public HttpResponseMessage DeleteConvenio(int id)
        {
            if (id <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Convenio convenio = _db.Convenio.Find(id);
            _db.Convenio.Remove(convenio);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, convenio);
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
