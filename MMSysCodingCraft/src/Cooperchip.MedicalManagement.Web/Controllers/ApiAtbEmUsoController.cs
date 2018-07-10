using Cooperchip.MedicalManagement.Domain.Entidade;
using Cooperchip.MedicalManagement.Infra.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System;

namespace Cooperchip.MedicalManagement.Web.Controllers
{
    /// <summary>
    /// APIs de controles de AtbEmUso
    /// </summary>
    [RoutePrefix("api/v1/evm")]
    public class ApiAtbEmUsoController : ApiController
    {

        //string erro = "";
        //PacienteValidator validador = new PacienteValidator();  => Descomentar quando criar AtbEmUsoValidator
        private MedicalManagementDbContext _db = new MedicalManagementDbContext();

        #region: AtbEmUso

        /// <summary>
        /// Obtem objetos AtbEmUso através dos Ids de Paciente 
        /// e também de Prontuário simultaneamente !!!
        /// </summary>
        /// <param name="idpc"></param>
        /// <param name="idpt"></param>
        /// <remarks>Obter AtbEmUso por Id do Paciente</remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("ObterAtbEmUsoPorPacienteEProntuario")]
        public HttpResponseMessage GetAtbEmUsoPorIdDoPaciente(Guid idpc, Guid idpt)
        {
            List<AtbEmUso> atbemuso = (from atbu in _db.AtbEmUso
                         .Include("Paciente")
                         .Include("Prontuario")
                                       select atbu).Where(x => x.PacienteId == idpc && x.ProntuarioGuid == idpt).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, atbemuso);
        }

        /// <summary>
        /// Obtem objetos AtbEmUso através do Id clicado para edição
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Obter AtbEmUsos por AtbEmUsoId</remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("ObterAtbEmUsoPorId")]
        public HttpResponseMessage GetAtbEmUsoPorId(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var atbeu = (from ant in _db.AtbEmUso.Include("Paciente") select ant).Where(x => x.AtbEmUsoId == id).FirstOrDefault();
            return Request.CreateResponse(HttpStatusCode.OK, atbeu);
        }

        /// <summary>
        /// Adiciona um objeto AtbEmUso através de um objeto AtbEmUso passado
        /// </summary>
        /// <param name="atbeu"></param>
        /// <returns>Adiciona um objeto AtbEmUso, recebido por parametro</returns>
        [HttpPost]
        [Route("AdicionarAtbEmUso")]
        public HttpResponseMessage AddAtbEmUso(AtbEmUso atbeu)
        {
            if (atbeu == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            _db.AtbEmUso.Add(atbeu);
            _db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, atbeu);
        }

        /// <summary>
        /// Altera um objeto AtbEmUso, através de um objeto passado por parâmetro
        /// </summary>
        /// <param name="atbeu"></param>
        /// <remarks>Altera um objeto AtbEmUso, através de um objeto passado por parâmetro</remarks>
        /// <returns></returns>
        [HttpPut]
        [Route("AlterarAtbEmUso")]
        public HttpResponseMessage PutAtbEmUso(AtbEmUso atbeu)
        {
            if (atbeu == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Entry(atbeu).State = EntityState.Modified;
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, atbeu);
        }


        /// <summary>
        /// Exclui um objeto AtbEmUso através do Id do Dreno passado
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Exclui um AtbEmUso Selecionado</remarks>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeletarAtbEmUso")]
        public HttpResponseMessage DelAtbEmUso(int id)
        {
            AtbEmUso atbeu = _db.AtbEmUso.Find(id);
            _db.AtbEmUso.Remove(atbeu);
            _db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, atbeu);
        }

        #endregion


        #region: If Exists e Disposing

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool AtbEmUsoExists(int id)
        {
            return _db.AtbEmUso.Count(e => e.AtbEmUsoId == id) > 0;
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
        #endregion

    }
}