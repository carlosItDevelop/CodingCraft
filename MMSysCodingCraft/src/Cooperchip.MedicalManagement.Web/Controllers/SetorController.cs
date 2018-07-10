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
    /// Controller de gestão de Setor
    /// </summary>
    [RoutePrefix("api/v1/evm")]
    public class SetorController : ApiController
    {


        private MedicalManagementDbContext _db = new MedicalManagementDbContext();

        /// <summary>
        /// Obtem uma coleção de Setor
        /// </summary>
        /// <remarks>Obtem uma coleção completa com todos os Setores</remarks>
        /// <returns></returns>
        [Route("ObterSetor")]
        public IQueryable<Setor> GetSetor()
        {
            return _db.Setor;
        }

        /// <summary>
        /// Obtem Setor por Id
        /// </summary>
        /// <remarks>Obtem um objeto Setor, através do parâmetro Id</remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("ObterSetorPorId")]
        public HttpResponseMessage GetSetor( int id )
        {
            if ( id <= 0 )
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Setor setor = _db.Setor.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, setor);
        }

        /// <summary>
        /// Altera um objeto Setor
        /// </summary>
        /// <remarks>Altera um objeto Setor, passando o obteto SEM seu Id</remarks>
        /// <param name="setor"></param>
        /// <returns></returns>
        [Route("AlterarSetor")]
        public HttpResponseMessage PutSetor( Setor setor )
        {
            if ( setor == null )
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Entry(setor).State = EntityState.Modified;
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, setor);
        }

        /// <summary>
        /// Adição de Setor
        /// </summary>
        /// <remarks>Cadastra um objeto Setor passando sua Descrição apenas</remarks>
        /// <param name="setor"></param>
        /// <returns></returns>
        [Route("AdicionarSetor")]
        public HttpResponseMessage PostSetor( Setor setor )
        {
            if ( setor == null )
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Setor.Add(setor);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, setor);
        }

        /// <summary>
        /// Exclusão de Setor
        /// </summary>
        /// <remarks>Exclusão de Setor através da passagem do parâmetro Id</remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("ExcluirSetor")]
        [ResponseType(typeof(Setor))]
        public HttpResponseMessage DeleteSetor( int id )
        {
            if ( id <= 0 )
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Setor setor = _db.Setor.Find(id);
            _db.Setor.Remove(setor);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, setor);
        }

        /// <summary>
        /// Realisa um dispose na entidade db
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing )
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }


    }




}
