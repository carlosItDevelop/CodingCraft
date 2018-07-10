using Cooperchip.MedicalManagement.Domain.Entidade;
using Cooperchip.MedicalManagement.Infra.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Cooperchip.MedicalManagement.Domain.Validations;

namespace Cooperchip.MedicalManagement.Web.Controllers
{

    /// <summary>
    /// Repositório de Resources das APIs de Genéricos do sistema
    /// </summary>
    [RoutePrefix("api/v1/evm")]
    public class ApiGenericosController : ApiController
    {

        /*string erro = "";*/
        PacienteValidator validador = new PacienteValidator();
        private MedicalManagementDbContext _db = new MedicalManagementDbContext();

        #region: Genéricos

        /// <summary>
        /// OBTER TODOS OS GENÉRICOS
        /// </summary>
        /// <remarks>OBTEM OS GENÉRICOS CADASTRADOS NA BASE DE DADOS SEM A NECESSIDADE DE PARÂMETROS</remarks>
        /// <returns></returns>
        [Route("ObterGenericos")]
        public IQueryable<Generico> GetGenerico()
        {
            return _db.Generico;
        }


        /// <summary>
        /// OBTER UM GENÉRICO POR ID DO GENÉRICO
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>OBTEM UM GENÉRICO ATRAVÉS DO ID DO GENÉRICO PASSADO.
        /// É DIFERENTE DO MÉTODO QUE RETORNA UM GENÉRICO ATRAVÉS DO ID DO MEDICAMENTO.
        /// </remarks>
        /// <returns></returns>
        [Route("ObterGenericoPorId")]
        [ResponseType(typeof(Generico))]
        public HttpResponseMessage GetGenerico(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Generico generico = _db.Generico.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, generico);
        }



        /// <summary>
        /// /
        /// </summary>
        /// <param name="generico"></param>
        /// <returns></returns>
        [Route("AlterarGenerico")]
        [ResponseType(typeof(void))]
        public HttpResponseMessage PutGenerico(Generico generico)
        {
            if (generico == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Entry(generico).State = EntityState.Modified;
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, generico);
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="generico"></param>
        /// <returns></returns>
        [Route("AdicionarGenerico")]
        [ResponseType(typeof(Generico))]
        public HttpResponseMessage PostGenerico(Generico generico)
        {
            if (generico == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Generico.Add(generico);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, generico);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("ExcluirGenerico")]
        public HttpResponseMessage DeleteGenerico(int id)
        {
            if (id <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Generico generico = _db.Generico.Find(id);
            _db.Generico.Remove(generico);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, generico);
        }

        /// <summary>
        /// Obtem um objeto Genérico através de um Id de medicamento no Objeto Medicamento.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Obter genérico através de medicamento</remarks>
        /// <returns></returns>        
        [Route("ObterGenericoPorMedicamento")]
        [ResponseType(typeof(Generico))]
        public HttpResponseMessage GetGenericoPorIdMedicamento(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var generico = (from g in _db.Medicamento select g).Where(x => x.MedicamentoId == id).FirstOrDefault();
            return Request.CreateResponse(HttpStatusCode.OK, generico);
        }
       
        #endregion:

        #region: If Exists e Disposing

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool DietaExists(int id)
        {
            return _db.Generico.Count(e => e.GenericoId == id) > 0;
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

        #endregion:

    }
}
