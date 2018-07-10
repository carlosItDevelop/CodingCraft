using Cooperchip.MedicalManagement.Domain.Entidade;
using Cooperchip.MedicalManagement.Infra.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System;
using Cooperchip.MedicalManagement.Domain.Validations;

namespace Cooperchip.MedicalManagement.Web.Controllers
{

    /// <summary>
    /// Repositório de Resources das APIs de Prontuario Precaucao do sistema
    /// </summary>
    [RoutePrefix("api/v1/evm")]
    public class ApiProntuarioPrecaucaoController : ApiController
    {

        //string erro = "";
        PacienteValidator validador = new PacienteValidator();
        private MedicalManagementDbContext _db = new MedicalManagementDbContext();

        #region: Prontuario Precaução



        /// <summary>
        /// Obetem os Objetos ProntuarioPrecaucao pelo id de Paciente e id de Prontuario
        /// </summary>
        /// <returns></returns>
        /// <remarks>Obtem ProntuarioPrecaucao por id de Paciente e Prontuario</remarks>
        [HttpGet]
        [Route("ObterProntuarioPrecaucaoPorIdPacienteEProntuario")]
        public HttpResponseMessage GetProntuarioPrecaucaoPorIdPaciente(Guid idpc, Guid idpt)
        {
            var pprecaucao = (from p in _db.ProntuarioPrecaucao.Include("TipoDePrecaucao").Include("Paciente").Include("Precaucao").Include("Prontuario") select p).Where(x => x.PacienteId == idpc && x.ProntuarioGuid == idpt).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, pprecaucao);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ObterUmProntuarioPrecaucaoPorId")]
        public HttpResponseMessage GetProntuarioPrecaucaoPorId(int? id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            ProntuarioPrecaucao pprecaucao = (from pp in _db.ProntuarioPrecaucao
                                   .Include("TipoDePrecaucao")
                                   .Include("Paciente")
                                   .Include("Precaucao")
                                              select pp).Where(x => x.ProntuarioPrecaucaoId == id).FirstOrDefault();

            return Request.CreateResponse(HttpStatusCode.OK, pprecaucao);
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="pprecaucao"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("AlterarProntuarioPrecaucao")]
        public HttpResponseMessage AletarProntuarioPrecaucao(ProntuarioPrecaucao pprecaucao)
        {
            if (pprecaucao == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Entry(pprecaucao).State = EntityState.Modified;
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, pprecaucao);
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="pprecaucao"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("AdicionarProntuarioPrecaucao")]
        public HttpResponseMessage AddProntuarioPrecaucao(ProntuarioPrecaucao pprecaucao)
        {
            if (pprecaucao == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.ProntuarioPrecaucao.Add(pprecaucao);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, pprecaucao);
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("ExcluirProntuarioPrecaucao")]
        public HttpResponseMessage ExcluirProntuarioPrecaucao(int id)
        {
            if (id <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            ProntuarioPrecaucao pprecaucao = _db.ProntuarioPrecaucao.Find(id);
            _db.ProntuarioPrecaucao.Remove(pprecaucao);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, pprecaucao);

        }


        #endregion

        #region: If Exist e Disposing

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool PrecaucaoExists(int id)
        {
            return _db.ProntuarioPrecaucao.Count(e => e.ProntuarioPrecaucaoId == id) > 0;
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
