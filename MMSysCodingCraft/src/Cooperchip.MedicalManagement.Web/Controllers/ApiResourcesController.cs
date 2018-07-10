using Cooperchip.MedicalManagement.Domain.Entidade;
using Cooperchip.MedicalManagement.Infra.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FluentValidation.Results;
using System;
using Cooperchip.MedicalManagement.Domain.Validations;

namespace Cooperchip.MedicalManagement.Web.Controllers
{

    /// <summary>
    /// Repositório de Resources das APIs do sistema
    /// </summary>
    [System.Web.Http.RoutePrefix("api/v1/evm")]
    public class ApiResourcesController : ApiController
    {

        string erro = "";
        PacienteValidator validador = new PacienteValidator();
        private MedicalManagementDbContext _db = new MedicalManagementDbContext();


        #region: Precaução



        /* ---------------------------------- */
        /* ---------------------------------- */
        /* ------ Precaução ----------------- */



        /// <summary>
        /// Obtem Precauções
        /// </summary>
        /// <remarks>Obtem uma lista com todas as Precauções</remarks>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ObterPrecaucaos")]
        public HttpResponseMessage ObterPrecaucao()
        {
            List<Precaucao> precaucao = (from p in _db.Precaucao
                                        .Include("TipoDePrecaucao")
                                         select p).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, precaucao);
        }

        /// <summary>
        /// Obter causas de Precauções
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ObterCausasPrecaucoes")]
        public HttpResponseMessage GetCausaPrecaucao(int? id)
        {
            var causaprecaucao = (from cp in _db.Precaucao
                                  select cp)
                                                .Where(x => x.IdTipoPrecaucao == id)
                                                .ToList();

            return Request.CreateResponse(HttpStatusCode.OK, causaprecaucao);
        }



        /// <summary>
        /// Obtem Precaução por Id
        /// </summary>
        /// <remarks>Obtem um objeto Precaucao, através do parâmetro Id</remarks>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ObterPrecaucaoPorId")]
        public HttpResponseMessage GetPrecaucaoPorId(int? id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Precaucao precaucao = (from p in _db.Precaucao
                                   .Include("TipoDePrecaucao")
                                   select p).Where(x => x.PrecaucaoId == id).FirstOrDefault();

            return Request.CreateResponse(HttpStatusCode.OK, precaucao);
        }



        /// <summary>
        /// Alterar um Precaucao
        /// </summary>
        /// <remarks>Alterar um Precaucao, através de um objeto passado e seu Id</remarks>
        /// <returns></returns>
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("AlterarPrecaucao")]
        public HttpResponseMessage AletarPrecaucao(Precaucao precaucao)
        {
            if (precaucao == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Entry(precaucao).State = EntityState.Modified;
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, precaucao);
        }


        /// <summary>
        /// Adiciona Precaucao
        /// </summary>
        /// <remarks>Adiciona Precaucao, através de um objeto passado SEM seu Id</remarks>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("AdicionarPrecaucao")]
        public HttpResponseMessage IncluirPrecaucao(Precaucao precaucao)
        {
            if (precaucao == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Precaucao.Add(precaucao);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, precaucao);
        }



        /// <summary>
        /// Exclui Precaucao
        /// </summary>
        /// <remarks>Exclui Precaucao, através de de seu Id</remarks>
        /// <returns></returns>
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("ExcluirPrecaucao")]
        public HttpResponseMessage ExcluirPrecaucao(int id)
        {
            if (id <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Precaucao precaucao = _db.Precaucao.Find(id);
            _db.Precaucao.Remove(precaucao);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, precaucao);

        }


        //ObterTiposDePrecaucoes
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ObterTiposDePrecaucoes")]
        public HttpResponseMessage GetTipoPrecaucao()
        {
            List<TipoDePrecaucao> tprecaucao = (from tp in _db.TipoDePrecaucao
                                                select tp).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, tprecaucao);
        }


        /* ---------------------------------- */
        /* ------ Fim de Precaucao ---------- */

        #endregion:

        #region: Prontuario



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("CriarNovoProntuario")]
        public HttpResponseMessage GetNewProntuario(Guid id)
        {
            Prontuario prontuario = new Prontuario()
            {
                NumAtendimento = "0000000",
                Paciente = (from p in _db.Paciente select p).Where(x => x.PacienteId == id).SingleOrDefault()

            };
            return Request.CreateResponse(HttpStatusCode.OK, prontuario);
        }



        /// <summary>
        /// Lista todos os prontuários de um paciente específico!
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ObterProntuarioPorId")]
        public HttpResponseMessage ObterUmProntuarioPorId(Guid id)
        {
            if (id == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            Prontuario prontuario = (from p in _db.Prontuario
                                     select p).Where(x => x.ProntuarioId == id).FirstOrDefault();
            return Request.CreateResponse(HttpStatusCode.OK, prontuario, "application/json");
        }


        /// <summary>
        /// Lista todos os prontuários de um paciente específico
        /// ou todos se não houver parâmetro!
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ObterTodosOsProntuarios")]
        public HttpResponseMessage ObterProntuarios(Guid? id)
        {
            IEnumerable<Prontuario> pronts;
            if (id != null)
            {
                pronts = (from p in _db.Prontuario select p).Where(x => x.PacienteId == id)
                    .OrderByDescending(x => x.DataProntuario).ToList();
            }
            else
            {
                pronts = (from p in _db.Prontuario select p).OrderByDescending(x => x.DataProntuario).ToList();
            }
            return Request.CreateResponse(HttpStatusCode.OK, pronts, "application/json");
        }


        /// <summary>
        /// Adiciona um novo prontuário para um paciente específico!
        /// </summary>
        /// <param name="prontuario"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AdicionarProntuario")]
        public HttpResponseMessage PostProntuario(Prontuario prontuario)
        {
            if (prontuario == null)
                return Request.CreateResponse<string>(HttpStatusCode.BadRequest, "Erro ao Adicionar Prontuario", "application/json");

            _db.Prontuario.Add(prontuario);
            _db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, prontuario, "application/json");
        }


        /// <summary>
        /// Altera um prontuário de um paciente específico!
        /// </summary>
        /// <param name="prontuario"></param>
        /// <returns></returns>
        [Route("AlterarProntuario")]
        public HttpResponseMessage PutProntuario(Prontuario prontuario)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse<string>(HttpStatusCode.BadRequest, "Erro ao Alterar Prontuario", "application/json");
            }
            _db.Entry(prontuario).State = EntityState.Modified;
            _db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, prontuario);
        }


        #endregion:

        #region: Prontuario Base


        /// <summary>
        /// 
        /// </summary>
        /// <param name="prontuario"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AdicionarProntuarioBase")]
        public HttpResponseMessage PostProntuarioBase(ProntuarioBase prontuario)
        {
            if (prontuario == null)
                return Request.CreateResponse<string>(HttpStatusCode.BadRequest, "Erro ao Adicionar Prontuario", "application/json");

            _db.ProntuarioBase.Add(prontuario);
            _db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, prontuario, "application/json");
        }


        /// <summary>
        /// Lista todos os prontuários de um paciente específico
        /// ou todos se não houver parâmetro!
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ObterTodosOsProntuariosBase")]
        public HttpResponseMessage ObterProntuariosBase(Guid? id)
        {
            IEnumerable<ProntuarioBase> pronts;
            if (id != null)
            {
                pronts = (from p in _db.ProntuarioBase select p).Where(x => x.PacienteId == id)
                    .OrderByDescending(x => x.DataProntuario).ToList();
            }
            else
            {
                pronts = (from p in _db.ProntuarioBase select p).OrderByDescending(x => x.DataProntuario).ToList();
            }
            return Request.CreateResponse(HttpStatusCode.OK, pronts, "application/json");
        }



        #endregion:

        #region: Prescricao


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ObterPrescricaoPorId")]
        public HttpResponseMessage ObterPrescricaoPorId(Guid id)
        {
            if (id == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var prescricao = (from p in _db.Prescricao
                              select p).Where(x => x.PrescricaoId == id).FirstOrDefault();

            return Request.CreateResponse(HttpStatusCode.OK, prescricao, "application/json");
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="idpc"></param>
        /// <param name="idpt"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ObterPrescricaoPorIdDePacienteEProntuario")]
        public HttpResponseMessage ObterUmaPrescricaoPorId(Guid idpc, Guid idpt)
        {
            if (idpc == null || idpt == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var prescricao = (from p in _db.Prescricao
                              select p).Where(x => x.PacienteId == idpc && x.ProntuarioGuid == idpt).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, prescricao, "application/json");
        }



        /// <summary>
        /// Adiciona um novo prontuário para um paciente específico!
        /// </summary>
        /// <param name="prescricao"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AdicionarPrescricao")]
        public HttpResponseMessage PostPrescricao(Prescricao prescricao)
        {
            if (prescricao == null)
                return Request.CreateResponse<string>(HttpStatusCode.BadRequest, "Erro ao Adicionar Prescrição", "application/json");

            _db.Prescricao.Add(prescricao);
            _db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, prescricao, "application/json");
        }


        /// <summary>
        /// Altera um prontuário de um paciente específico!
        /// </summary>
        /// <param name="prescricao"></param>
        /// <returns></returns>
        [Route("AlterarPrescricao")]
        public HttpResponseMessage PutPrescricao(Prescricao prescricao)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse<string>(HttpStatusCode.BadRequest, "Erro ao Alterar Prescrição", "application/json");
            }
            _db.Entry(prescricao).State = EntityState.Modified;
            _db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, prescricao);
        }



        #endregion:

        #region: Estado do Paciente

        /* ---------------------------------- */
        /* ---------------------------------- */
        /* ------ Estado do Paciente -------- */


        /// <summary>
        /// Obtem uma coleção de EstadoDoPaciente
        /// </summary>
        /// <remarks>Obtem uma coleção completa com todos os EstadoDoPacientes</remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("ObterEstadoDoPaciente")]
        public IQueryable<EstadoDoPaciente> GetEstadoDoPaciente()
        {
            return _db.EstadoDoPaciente;
        }

        /// <summary>
        /// Obtem EstadoDoPaciente por Id
        /// </summary>
        /// <remarks>Obtem um objeto EstadoDoPaciente, através do parâmetro Id</remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ObterEstadoDoPacientePorId")]
        public HttpResponseMessage GetEstadoDoPaciente(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            EstadoDoPaciente estadoDoPaciente = _db.EstadoDoPaciente.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, estadoDoPaciente);
        }

        /// <summary>
        /// Altera um objeto EstadoDoPaciente
        /// </summary>
        /// <remarks>Altera um objeto EstadoDoPaciente, passando o obteto SEM seu Id</remarks>
        /// <param name="estadoDoPaciente"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("AlterarEstadoDoPaciente")]
        public HttpResponseMessage PutEstadoDoPaciente(EstadoDoPaciente estadoDoPaciente)
        {
            if (estadoDoPaciente == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Entry(estadoDoPaciente).State = EntityState.Modified;
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, estadoDoPaciente);
        }

        /// <summary>
        /// Adição de EstadoDoPaciente
        /// </summary>
        /// <remarks>Cadastra um objeto EstadoDoPaciente passando sua Descrição apenas</remarks>
        /// <param name="estadoDoPaciente"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AdicionarEstadoDoPaciente")]
        public HttpResponseMessage PostEstadoDoPaciente(EstadoDoPaciente estadoDoPaciente)
        {
            if (estadoDoPaciente == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.EstadoDoPaciente.Add(estadoDoPaciente);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, estadoDoPaciente);
        }

        /// <summary>
        /// Exclusão de EstadoDoPaciente
        /// </summary>
        /// <remarks>Exclusão de EstadoDoPaciente através da passagem do parâmetro Id</remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("ExcluirEstadoDoPaciente")]
        public HttpResponseMessage DeleteEstadoDoPaciente(int id)
        {
            if (id <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            EstadoDoPaciente estadoDoPaciente = _db.EstadoDoPaciente.Find(id);
            _db.EstadoDoPaciente.Remove(estadoDoPaciente);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, estadoDoPaciente);
        }



        #endregion:

        #region: Complicação

        /* ---------------------------------- */
        /* ---------------------------------- */
        /* ------ Complicacao --------------- */


        /// <summary>
        /// Obtem uma coleção de Complicacao
        /// </summary>
        /// <remarks>Obtem uma coleção completa com todos os Complicacaos</remarks>
        /// <returns></returns>
        [Route("ObterComplicacao")]
        public IQueryable<Complicacao> GetComplicacao()
        {
            return _db.Complicacao;
        }

        /// <summary>
        /// Obtem Complicacao por Id
        /// </summary>
        /// <remarks>Obtem um objeto Complicacao, através do parâmetro Id</remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("ObterComplicacaoPorId")]
        public HttpResponseMessage GetComplicacao(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Complicacao complicacao = _db.Complicacao.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, complicacao);
        }

        /// <summary>
        /// Altera um objeto Complicacao
        /// </summary>
        /// <remarks>Altera um objeto Complicacao, passando o obteto SEM seu Id</remarks>
        /// <param name="complicacao"></param>
        /// <returns></returns>
        [Route("AlterarComplicacao")]
        public HttpResponseMessage PutComplicacao(Complicacao complicacao)
        {
            if (complicacao == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Entry(complicacao).State = EntityState.Modified;
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, complicacao);
        }

        /// <summary>
        /// Adição de Complicacao
        /// </summary>
        /// <remarks>Cadastra um objeto Complicacao passando sua Descrição apenas</remarks>
        /// <param name="complicacao"></param>
        /// <returns></returns>
        [Route("AdicionarComplicacao")]
        public HttpResponseMessage PostComplicacao(Complicacao complicacao)
        {
            if (complicacao == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Complicacao.Add(complicacao);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, complicacao);
        }

        /// <summary>
        /// Exclusão de Complicacao
        /// </summary>
        /// <remarks>Exclusão de Complicacao através da passagem do parâmetro Id</remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("ExcluirComplicacao")]
        [ResponseType(typeof(Complicacao))]
        public HttpResponseMessage DeleteComplicacao(int id)
        {
            if (id <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Complicacao complicacao = _db.Complicacao.Find(id);
            _db.Complicacao.Remove(complicacao);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, complicacao);
        }



        #endregion:

        #region: Tipo de Dreno

        /* ---------------------------------- */
        /* ---------------------------------- */
        /* ------ Tipo de Dreno ------------- */


        /// <summary>
        /// Obter uma lista de objetos tipos de dreno
        /// </summary>
        /// <remarks>Obter todos os tipos de dreno</remarks>
        /// <returns></returns>
        [Route("ApiObeterTodosOsTipoDrenos")]
        public HttpResponseMessage GetAllTipoDreno()
        {
            var tipodreno = (from td in _db.TipoDreno select td).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, tipodreno);
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ApiObterTipoDrenoPorId")]
        public HttpResponseMessage GetApiTipoDrenoPorId(int? id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var tipodreno = (from td in _db.TipoDreno select td).Where(x => x.TipoDrenoId == id).FirstOrDefault();
            return Request.CreateResponse(HttpStatusCode.OK, tipodreno);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="tipodreno"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("AlterarTipoDreno")]
        public HttpResponseMessage PutTipoDreno(TipoDreno tipodreno)
        {
            if (tipodreno == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Entry(tipodreno).State = EntityState.Modified;
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, tipodreno);
        }

        /// <summary>
        /// Adicionar um novo Tipo de Dreno
        /// </summary>
        /// <param name="tipodreno"></param>
        /// <remarks>Adicionar um objeto TipoDreno para seleção na API de dreno</remarks>
        /// <returns></returns>
        [HttpPost]
        [Route("AdicionarUmTipoDreno")]
        public HttpResponseMessage PostTipoDreno(TipoDreno tipodreno)
        {
            if (tipodreno == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.TipoDreno.Add(tipodreno);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, tipodreno);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("ExcluirTipoDreno")]
        public HttpResponseMessage DeleteTipoDreno(int id)
        {
            if (id <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            TipoDreno tipodreno = _db.TipoDreno.Find(id);
            _db.TipoDreno.Remove(tipodreno);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, tipodreno);
        }


        #endregion

        #region: Pacientes

        /* ---------------------------------- */
        /* ---------------------------------- */
        /* ------ Paciente ------------------ */


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("ApiObeterTodosOsPacientes")]
        public HttpResponseMessage GetAllApiPaciente()
        {
            var paciente = (from p in _db.Paciente select p).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, paciente);
        }

        // ApiObeterPacientesRightSidebar  // Pesquisar mais LazyLoading;
        /// <summary>
        /// Obter apenas alguns dados dos pacientes para a RightSidebar
        /// </summary>
        /// <returns></returns>
        /// <remarks>Obter apenas alguns dados dos pacientes para a RightSidebar</remarks>
        [Route("ApiObeterPacientesRightSidebar")]
        public HttpResponseMessage GetAllPacienteRightSidebar()
        {
            var paciente = (from p in _db.Paciente
                            .Include("Leito")
                            .Include("EstadoDoPaciente")
                            select new
                            {
                                p.PacienteId,
                                p.PessoaFisica.NomeOuRazaoSocial,
                                p.Leito,
                                p.EstadoDoPaciente
                            }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, paciente);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ApiObterPacientePorId")]
        public HttpResponseMessage GetApiPacientePorId(Guid? id)
        {
            if (id == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var paciente = (from p in _db.Paciente select p)
                                         .Where(x => x.PacienteId == id)
                                         .FirstOrDefault();

            return Request.CreateResponse(HttpStatusCode.OK, paciente);
        }


        //CriarNovopaciente
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("CriarNovopaciente")]
        public HttpResponseMessage GetNewPaciente()
        {

            Paciente paciente = new Paciente();

            return Request.CreateResponse(HttpStatusCode.OK, paciente);
        }


        // AlterarPaciente
        /// <summary>
        ///
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns></returns>
        [Route("AlterarPaciente")]
        public HttpResponseMessage PutPaciente(Paciente paciente)
        {
            ValidationResult resultado = validador.Validate(paciente);

            if (!resultado.IsValid)
            {
                //resultado.Errors.ToList().ForEach(e => erro += $"{e.PropertyName} : {e.ErrorMessage}" + Environment.NewLine);
                resultado.Errors.ToList().ForEach(e => erro += $"{e.ErrorMessage}" + "\n\r");
                return Request.CreateResponse<string>(HttpStatusCode.BadRequest, erro, "application/json");
            }

            _db.Entry(paciente).State = EntityState.Modified;
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, paciente);
        }


        // AdicionarPaciente
        /// <summary>
        ///
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AdicionarUmPaciente")]
        public HttpResponseMessage PostPaciente(Paciente paciente)
        {
            if (paciente == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Paciente.Add(paciente);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, paciente);
        }


        // ExcluirPaciente
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("ExcluirPaciente")]
        public HttpResponseMessage DeletePaciente(Guid id)
        {
            if (id == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Paciente paciente = _db.Paciente.Find(id);

            var temprontuario = (from prt in _db.Prontuario select prt).Where(x => x.PacienteId == id).Count();
            if (temprontuario > 0)
            {
                return Request.CreateResponse<string>(HttpStatusCode.BadRequest, "Paciente com Prontuário. Não deve ser excluído!", "application/json");
            }
            _db.Paciente.Remove(paciente);
            _db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, paciente);
        }



        #endregion:

        #region: Endereço

        /* ---------------------------------- */
        /* ---------------------------------- */
        /* ------ Endereço ------------------ */

        /// <summary>
        /// Obtem as Descrições das UFs
        /// </summary>
        /// <remarks>Obtem uma lista com as descrições de todas as UFs</remarks>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ObterUfsParaEndereco")]
        public IQueryable<Uf> GetUfs()
        {
            return _db.Uf;
        }


        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ObterNomePacientes")]
        public HttpResponseMessage GetNomePacienteParaEndereco()
        {
            var nomePaciente = (from p in _db.Paciente select new { p.PacienteId, p.PessoaFisica.NomeOuRazaoSocial }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, nomePaciente);
        }




        /// <summary>
        /// Obtem as Descrições dos Bairros
        /// </summary>
        /// <remarks>Obtem uma lista com as descrições de todos os Bairros</remarks>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ObterBairrosParaEndereco")]
        public IQueryable<Bairro> GetBairros()
        {
            return _db.Bairro;
        }


        /// <summary>
        /// Obtem as Descrições das Cidades
        /// </summary>
        /// <remarks>Obtem uma lista com as descrições de todas as Cidades</remarks>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ObterCidadesParaEndereco")]
        public IQueryable<Cidade> GetCidades()
        {
            return _db.Cidade;
        }

        // ---/ --------------------------------------


        /// <summary>
        /// Obtem os Endereços
        /// </summary>
        /// <remarks>Obtem uma lista com todos os Endereços</remarks>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ObterEnderecos")]
        public List<Endereco> GetEndereco()
        {

            var endereco = _db.Endereco
                .Include(e => e.Bairro)
                .Include(e => e.Cidade)
                .Include(e => e.Paciente)
                .Include(e => e.Uf);
            return endereco.ToList();

            //var endereco = (from e in _db.Endereco select e).ToList();
            //return endereco;
        }


        /// <summary>
        /// Obtem um Endereço por Id
        /// </summary>
        /// <remarks>Obtem um objeto Endereço, através do parâmetro Id</remarks>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ObterEnderecoPorId")]
        public HttpResponseMessage GetEndereco(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Endereco endereco = _db.Endereco.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, endereco);
        }

        /// <summary>
        /// Alterar um Endereço
        /// </summary>
        /// <remarks>Alterar um Endereço, através de um objeto passado e seu Id</remarks>
        /// <returns></returns>
        [System.Web.Http.Route("AlterarEndereco")]
        public HttpResponseMessage PutEndereco(Endereco endereco)
        {
            if (endereco == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Entry(endereco).State = EntityState.Modified;
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, endereco);
        }


        /// <summary>
        /// Adiciona um Endereço
        /// </summary>
        /// <remarks>Adiciona um Endereço, através de um objeto passado SEM seu Id</remarks>
        /// <returns></returns>
        //[HttpPost]
        [System.Web.Http.Route("AdicionarEndereco")]
        public HttpResponseMessage PostEndereco(Endereco endereco)
        {
            if (endereco == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Endereco.Add(endereco);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, endereco);
        }


        /// <summary>
        /// Exclui um Endereço
        /// </summary>
        /// <remarks>Exclui um Endereço, através de de seu Id</remarks>
        /// <returns></returns>
        //[HttpDelete]
        [System.Web.Http.Route("ExcluirEndereco")]
        public HttpResponseMessage DeleteEndereco(int id)
        {
            if (id <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Endereco endereco = _db.Endereco.Find(id);
            _db.Endereco.Remove(endereco);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, endereco);
        }

        #endregion:

        #region: Medico

        /* ---------------------------------- */
        /* ---------------------------------- */
        /* ------ Medico -------------------- */

        /// <summary>
        /// Obtem a lista completa de médicos para a rotina de agendamentos
        /// </summary>
        /// <remarks>Obter lista de médicos para agendamento</remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("ObterMedicos")]
        public HttpResponseMessage GetMedicos()
        {
            var medico = (from md in _db.Medico.Include("Especialidade") select md).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, medico);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ObterMedicoPorId")]
        public HttpResponseMessage GetMedico(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Medico medico = _db.Medico.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, medico);
        }

        //AdicionarMedico
        // Post
        /// <summary>
        ///
        /// </summary>
        /// <param name="medico"></param>
        /// <returns></returns>
        [Route("AdicionarMedico")]
        public HttpResponseMessage PostMedico(Medico medico)
        {
            if (medico == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Medico.Add(medico);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, medico);
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="medico"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("AlterarMedico")]
        public HttpResponseMessage PutMedico(Medico medico)
        {
            if (medico == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Entry(medico).State = EntityState.Modified;
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, medico);
        }


        //ExcluirMedico

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("ExcluirMedico")]
        public HttpResponseMessage DeleteMedico(int id)
        {
            if (id <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Medico medico = _db.Medico.Find(id);
            _db.Medico.Remove(medico);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, medico);
        }



        #endregion:

        #region: Agendamento

        /* ---------------------------------- */
        /* ---------------------------------- */
        /* ------ Agendamento --------------- */


        //[Route("ObterMedicos")]  => Mesmo serviço de Medico



        /// <summary>
        /// Obtem a lista completa de agendamentos para consulta
        /// </summary>
        /// <remarks>Obter lista de agendamentos</remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("ObterAgendamentos")]
        public List<Agendamento> GetAgendamento()
        {

            var agendamento = (from ag in _db.Agendamento
                               .Include("Medico")
                               .Include("Paciente")
                               select ag).ToList();

            return agendamento;
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ObterAgendamentoPorId")]
        public HttpResponseMessage GetAgendamento(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Agendamento agendamento = _db.Agendamento.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, agendamento);
        }



        /// <summary>
        ///
        /// </summary>
        /// <param name="agendamento"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("AlterarAgendamento")]
        public HttpResponseMessage PutAgendamento(Agendamento agendamento)
        {
            if (agendamento == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Entry(agendamento).State = EntityState.Modified;
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, agendamento);
        }

        // Post
        /// <summary>
        ///
        /// </summary>
        /// <param name="agendamento"></param>
        /// <returns></returns>
        [Route("AdicionarAgendamento")]
        public HttpResponseMessage PostAgendamento(Agendamento agendamento)
        {
            if (agendamento == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Agendamento.Add(agendamento);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, agendamento);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("ExcluirAgendamento")]
        public HttpResponseMessage DeleteAgendamento(int id)
        {
            if (id <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Agendamento agendamento = _db.Agendamento.Find(id);
            _db.Agendamento.Remove(agendamento);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, agendamento);
        }

        #endregion:

        #region: Anticoagulação

        /* ---------------------------------- */
        /* ---------------------------------- */
        /* ------ Anticoagulacao ------------ */


        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [Route("ObterAnticoagulacao")]
        public IQueryable<Anticoagulacao> GetAnticoagulacao()
        {
            return _db.Anticoagulacao;
        }

        /// <summary>
        /// Obtem Anticoagulação por Id
        /// </summary>
        /// <remarks>Obtem um objeto Anticoagulação, através do paâmetro Id</remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("ObterAnticoagulacaoPorId")]
        public HttpResponseMessage GetAnticoagulacao(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Anticoagulacao anticoagulacao = _db.Anticoagulacao.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, anticoagulacao);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="anticoagulacao"></param>
        /// <returns></returns>
        [Route("AlterarAnticoagulacao")]
        public HttpResponseMessage PutAnticoagulacao(Anticoagulacao anticoagulacao)
        {
            if (anticoagulacao == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Entry(anticoagulacao).State = EntityState.Modified;
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, anticoagulacao);
        }

        /// <summary>
        /// Adição de Anticoagulação
        /// </summary>
        /// <remarks>Cadastra um objeto Anticoagulação passando sua Descrição apenas</remarks>
        /// <param name="anticoagulacao"></param>
        /// <returns></returns>
        [Route("AdicionarAnticoagulacao")]
        public HttpResponseMessage PostAnticoagulacao(Anticoagulacao anticoagulacao)
        {
            if (anticoagulacao == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Anticoagulacao.Add(anticoagulacao);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, anticoagulacao);
        }

        /// <summary>
        /// Exclusão de Anticoagulação
        /// </summary>
        /// <remarks>Exclusão de Anticoagulação através da passagem do parâmetro Id</remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("ExcluirAnticoagulacao")]
        [ResponseType(typeof(Anticoagulacao))]
        public HttpResponseMessage DeleteAnticoagulacao(int id)
        {
            if (id <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Anticoagulacao anticoagulacao = _db.Anticoagulacao.Find(id);
            _db.Anticoagulacao.Remove(anticoagulacao);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, anticoagulacao);
        }


        #endregion:

        #region: Fisioterapia

        /// <summary>
        /// Obtem uma coleção de Fisioterapia
        /// </summary>
        /// <remarks>Obtem uma coleção completa com todas as Fisioterapias</remarks>
        /// <returns></returns>
        [Route("ObterFisioterapia")]
        public IQueryable<Fisioterapia> GetFisioterapia()
        {
            return _db.Fisioterapia;
        }

        /// <summary>
        /// Obtem Fisioterapia por Id
        /// </summary>
        /// <remarks>Obtem um objeto Fisioterapia, através do parâmetro Id</remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("ObterFisioterapiaPorId")]
        public HttpResponseMessage GetFisioterapia(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Fisioterapia fisioterapia = _db.Fisioterapia.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, fisioterapia);
        }

        /// <summary>
        /// Altera um objeto Fisioterapia
        /// </summary>
        /// <remarks>Altera um objeto Fisioterapia, passando um obteto inteiro SEM seu Id</remarks>
        /// <param name="fisioterapia"></param>
        /// <returns></returns>
        [Route("AlterarFisioterapia")]
        public HttpResponseMessage PutFisioterapia(Fisioterapia fisioterapia)
        {
            if (fisioterapia == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Entry(fisioterapia).State = EntityState.Modified;
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, fisioterapia);
        }

        /// <summary>
        /// Adição de Fisioterapia
        /// </summary>
        /// <remarks>Cadastra um objeto Fisioterapia passando sua Descrição apenas</remarks>
        /// <param name="fisioterapia"></param>
        /// <returns></returns>
        [Route("AdicionarFisioterapia")]
        public HttpResponseMessage PostFisioterapia(Fisioterapia fisioterapia)
        {
            if (fisioterapia == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Fisioterapia.Add(fisioterapia);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, fisioterapia);
        }

        /// <summary>
        /// Exclusão de Fisioterapia
        /// </summary>
        /// <remarks>Exclusão de Fisioterapia através da passagem do parâmetro Id</remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("ExcluirFisioterapia")]
        [ResponseType(typeof(Fisioterapia))]
        public HttpResponseMessage DeleteFisioterapia(int id)
        {
            if (id <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Fisioterapia fisioterapia = _db.Fisioterapia.Find(id);
            _db.Fisioterapia.Remove(fisioterapia);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, fisioterapia);
        }


        #endregion:

        #region: Dieta

        /* ---------------------------------- */
        /* ---------------------------------- */
        /* ------ Dieta --------------------- */

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [Route("ObterDietas")]
        public IQueryable<Dieta> GetDieta()
        {
            return _db.Dieta;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("ObterDietaPorId")]
        public HttpResponseMessage GetDieta(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Dieta dieta = _db.Dieta.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, dieta);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dieta"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("AlterarDieta")]
        public HttpResponseMessage PutDieta(Dieta dieta)
        {
            if (dieta == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Entry(dieta).State = EntityState.Modified;
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, dieta);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dieta"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AdicionarDieta")]
        public HttpResponseMessage PostDieta(Dieta dieta)
        {
            if (dieta == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Dieta.Add(dieta);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, dieta);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("ExcluirDieta")]
        public HttpResponseMessage DeleteDieta(int id)
        {
            if (id <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Dieta dieta = _db.Dieta.Find(id);
            _db.Dieta.Remove(dieta);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, dieta);
        }



        #endregion:

        #region: Especialidade

        /* ---------------------------------- */
        /* ---------------------------------- */
        /* ------ Especialidade ------------- */


        /// <summary>
        /// Obtem uma coleção de Especialidade
        /// </summary>
        /// <remarks>Obtem uma coleção completa com todos os Especialidades</remarks>
        /// <returns></returns>
        [Route("ObterEspecialidade")]
        public IQueryable<Especialidade> GetEspecialidade()
        {
            return _db.Especialidade;
        }

        /// <summary>
        /// Obtem Especialidade por Id
        /// </summary>
        /// <remarks>Obtem um objeto Especialidade, através do parâmetro Id</remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("ObterEspecialidadePorId")]
        public HttpResponseMessage GetEspecialidade(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Especialidade especialidade = _db.Especialidade.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, especialidade);
        }

        /// <summary>
        /// Altera um objeto Especialidade
        /// </summary>
        /// <remarks>Altera um objeto Especialidade, passando o obteto SEM seu Id</remarks>
        /// <param name="especialidade"></param>
        /// <returns></returns>
        [Route("AlterarEspecialidade")]
        public HttpResponseMessage PutEspecialidade(Especialidade especialidade)
        {
            if (especialidade == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Entry(especialidade).State = EntityState.Modified;
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, especialidade);
        }

        /// <summary>
        /// Adição de Especialidade
        /// </summary>
        /// <remarks>Cadastra um objeto Especialidade passando sua Descrição apenas</remarks>
        /// <param name="especialidade"></param>
        /// <returns></returns>
        [Route("AdicionarEspecialidade")]
        public HttpResponseMessage PostEspecialidade(Especialidade especialidade)
        {
            if (especialidade == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Especialidade.Add(especialidade);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, especialidade);
        }

        /// <summary>
        /// Exclusão de Especialidade
        /// </summary>
        /// <remarks>Exclusão de Especialidade através da passagem do parâmetro Id</remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("ExcluirEspecialidade")]
        [ResponseType(typeof(Especialidade))]
        public HttpResponseMessage DeleteEspecialidade(int id)
        {
            if (id <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Especialidade especialidade = _db.Especialidade.Find(id);
            _db.Especialidade.Remove(especialidade);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, especialidade);
        }




        #endregion:

        #region: Dreno

        // -----/ Drenos ---------------------------------------- //

        /// <summary>
        /// Obter tipos de Drenos para DropDrownList
        /// </summary>
        /// <remarks>Preenche DropDrownList de Tipos de Drenos</remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("ObterTipoDeDreno")]
        public HttpResponseMessage GetTipoDeDreno()
        {
            var tipodreno = (from td in _db.TipoDreno
                             select td).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, tipodreno);
        }


        /// <summary>
        /// Obtem objetos Drenos através dos Ids de Paciente 
        /// e também de Prontuário simultaneamente !!!
        /// </summary>
        /// <param name="idpc"></param>
        /// <param name="idpt"></param>
        /// <remarks>Obter Drenos por Id do Paciente</remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("ObterDrenoPorPacienteEProntuario")]
        public HttpResponseMessage GetDrenoPorIdDoPaciente(Guid idpc, Guid idpt)
        {
            List<Dreno> dreno = (from dn in _db.Dreno
                         .Include("Paciente")
                         .Include("Prontuario")
                         .Include("TipoDreno")
                                 select dn).Where(x => x.PacienteId == idpc && x.ProntuarioGuid == idpt).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, dreno);
        }



        /// <summary>
        /// Obtem objetos Drenos através do Id clicado para edição
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Obter Drenos por DrenoId</remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("ObterDrenoPorId")]
        public HttpResponseMessage GetDrenoPorId(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var dreno = (from dn in _db.Dreno.Include("Paciente") select dn).Where(x => x.DrenoId == id).FirstOrDefault();
            return Request.CreateResponse(HttpStatusCode.OK, dreno);
        }



        /// <summary>
        /// Adiciona um objeto Dreno através de um objeto Dreno passado
        /// </summary>
        /// <param name="dreno"></param>
        /// <returns>Adiciona um objeto Dreno, recebido por parametro</returns>
        [HttpPost]
        [Route("AdicionarDreno")]
        public HttpResponseMessage AddDreno(Dreno dreno)
        {
            if (dreno == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            _db.Dreno.Add(dreno);
            _db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, dreno);
        }


        /// <summary>
        /// Altera um objeto Dreno, através de um objeto passado por parâmetro
        /// </summary>
        /// <param name="dreno"></param>
        /// <remarks>Altera um objeto Dreno, através de um objeto passado por parâmetro</remarks>
        /// <returns></returns>
        [HttpPut]
        [Route("AlterarDreno")]
        public HttpResponseMessage PutDreno(Dreno dreno)
        {
            if (dreno == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Entry(dreno).State = EntityState.Modified;
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, dreno);
        }



        /// <summary>
        /// Exclui um objeto Dreno através do Id do Dreno passado
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Exclui um Dreno Selecionado</remarks>
        /// <returns></returns>
        [HttpDelete]
        [Route("ExcluirDreno")]
        public HttpResponseMessage DeletarDreno(int id)
        {
            Dreno dreno = _db.Dreno.Find(id);
            _db.Dreno.Remove(dreno);
            _db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, dreno);
        }

        #endregion:

        #region: ChamadaMedico


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetChamadaMedicos")]
        public IQueryable<ChamadaMedico> ObterChamadaMedico()
        {
            return _db.ChamadaMedico;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetChamadaMedicoPorId/{id:int}")]
        public HttpResponseMessage ObeterChamadaMedicoPorId(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            ChamadaMedico chamadamedico = _db.ChamadaMedico.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, chamadamedico);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chamadamedico"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("PutChamadaMedico")]
        public HttpResponseMessage AletarChamadaMedico(ChamadaMedico chamadamedico)
        {
            if (chamadamedico == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Entry(chamadamedico).State = EntityState.Modified;
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, chamadamedico);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chamadamedico"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PostChamadaMedico")]
        public HttpResponseMessage IncluirChamadaMedico(ChamadaMedico chamadamedico)
        {
            if (chamadamedico == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.ChamadaMedico.Add(chamadamedico);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, chamadamedico);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DelChamadaMedico/{id:int}")]
        public HttpResponseMessage ExcluirChamadaMedico(int id)
        {
            if (id <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            ChamadaMedico chamadamedico = _db.ChamadaMedico.Find(id);
            _db.ChamadaMedico.Remove(chamadamedico);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, chamadamedico);

        }


        // ------------------------------------------------------------------ //

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetMedicosEmChamadaMedico")]
        public HttpResponseMessage ObterTodosOsMedicos()
        {
            var medicos = (from m in _db.Medico select m.Nome).ToList().AsQueryable();

            return Request.CreateResponse(HttpStatusCode.OK, medicos);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetLeitosEmChamadaMedico")]
        public HttpResponseMessage ObterLeitos()
        {
            var leitos = (from l in _db.Leito select l.EspecificacaoDoLeito).ToList().AsQueryable();
            return Request.CreateResponse(HttpStatusCode.OK, leitos);
        }



        #endregion:

        #region: IfExiste e Disposing

        /* ---------------------------------- */
        /* ---------------------------------- */
        /* ------ IfExiste e Disposing ------ */

        private bool PrescricaoExiste(Guid id)
        {
            return _db.Prescricao.Count(e => e.PrescricaoId == id) > 0;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool PrecaucaoExists(int id)
        {
            return _db.Precaucao.Count(e => e.PrecaucaoId == id) > 0;
        }

        private bool ChamadaMedicoExists(int id)
        {
            return _db.ChamadaMedico.Count(e => e.ChamadaMedicoId == id) > 0;
        }


        private bool DrenoExists(int id)
        {
            return _db.Dreno.Count(e => e.DrenoId == id) > 0;
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool ComplicacaoExists(int id)
        {
            return _db.Complicacao.Count(e => e.ComplicacaoId == id) > 0;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool MedicoExists(Guid id)
        {
            return _db.Medico.Count(e => e.MedicoId == id) > 0;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool EspecialidadeExists(int id)
        {
            return _db.Especialidade.Count(e => e.EspecialidadeId == id) > 0;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool PacienteExists(Guid id)
        {
            return _db.Paciente.Count(e => e.PacienteId == id) > 0;
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool AnticoagulacaoExists(int id)
        {
            return _db.Anticoagulacao.Count(e => e.AnticoagulacaoId == id) > 0;
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool AgendamentoExists(int id)
        {
            return _db.Agendamento.Count(e => e.AgendamentoId == id) > 0;
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool DietaExists(int id)
        {
            return _db.Dieta.Count(e => e.DietaId == id) > 0;
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
