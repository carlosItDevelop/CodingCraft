using Cooperchip.MedicalManagement.Infra.Data;
using Cooperchip.MedicalManagement.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cooperchip.MedicalManagement.Web.Controllers
{

    /// <summary>
    /// APIs de controles de AtbJaUtilizado
    /// </summary>
    [RoutePrefix("api/v1/evm")]
    public class ApiAtbJaUtilizadoController : ApiController
    {

        //string erro = "";
        //PacienteValidator validador = new PacienteValidator();  => Descomentar quando criar AtbEmUsoValidator
        private MedicalManagementDbContext _db = new MedicalManagementDbContext();

        #region: AtbJaUtilizado

        /// <summary>
        /// Obtem objetos AtbJaUtilizado através dos Ids de Paciente 
        /// e também de Prontuário simultaneamente !!!
        /// </summary>
        /// <param name="idpc"></param>
        /// <param name="idpt"></param>
        /// <remarks>Obter AtbJaUtilizado por Id do Paciente</remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("ObterAtbJaUtilizadoPorPacienteEProntuario")]
        public HttpResponseMessage GetAtbJaUtilizadoPorIdDoPaciente(Guid idpc, Guid idpt)
        {
            List<AtbJaUtilizado> atbjautilizado = (from atbu in _db.AtbJaUtilizado
                         .Include("Paciente")
                         .Include("Prontuario")
                                       select atbu).Where(x => x.PacienteId == idpc && x.ProntuarioGuid == idpt).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, atbjautilizado);
        }

        /// <summary>
        /// Obtem objetos AtbJaUtilizado através do Id clicado para edição
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Obter AtbJaUtilizados por AtbEmUsoId</remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("ObterAtbJaUtilizadoPorId")]
        public HttpResponseMessage GetAtbJaUtilizadoPorId(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var atbju = (from ant in _db.AtbJaUtilizado.Include("Paciente") select ant).Where(x => x.AtbJaUtilizadoId == id).FirstOrDefault();
            return Request.CreateResponse(HttpStatusCode.OK, atbju);
        }

        /// <summary>
        /// Adiciona um objeto AtbJaUtilizado através de um objeto AtbJaUtilizado passado
        /// </summary>
        /// <param name="atbju"></param>
        /// <returns>Adiciona um objeto AtbJaUtilizado, recebido por parametro</returns>
        [HttpPost]
        [Route("AdicionarAtbJaUtilizado")]
        public HttpResponseMessage AddAtbEmUso(AtbJaUtilizado atbju)
        {
            if (atbju == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            _db.AtbJaUtilizado.Add(atbju);
            _db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, atbju);
        }

        /// <summary>
        /// Altera um objeto AtbJaUtilizado, através de um objeto passado por parâmetro
        /// </summary>
        /// <param name="atbju"></param>
        /// <remarks>Altera um objeto AtbJaUtilizado, através de um objeto passado por parâmetro</remarks>
        /// <returns></returns>
        [HttpPut]
        [Route("AlterarAtbJaUtilizado")]
        public HttpResponseMessage PutAtbJaUtilizado(AtbJaUtilizado atbju)
        {
            if (atbju == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Entry(atbju).State = EntityState.Modified;
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, atbju);
        }


        /// <summary>
        /// Exclui um objeto AtbJaUtilizado através do Id do Dreno passado
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Exclui um AtbJaUtilizado Selecionado</remarks>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeletarAtbJaUtilizado")]
        public HttpResponseMessage DelAtbJaUtilizado(int id)
        {
            AtbJaUtilizado atbju = _db.AtbJaUtilizado.Find(id);
            _db.AtbJaUtilizado.Remove(atbju);
            _db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, atbju);
        }

        #endregion:


        #region: If Exists e Disposing

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool AtbJaUtilizadoExists(int id)
        {
            return _db.AtbJaUtilizado.Count(e => e.AtbJaUtilizadoId == id) > 0;
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
