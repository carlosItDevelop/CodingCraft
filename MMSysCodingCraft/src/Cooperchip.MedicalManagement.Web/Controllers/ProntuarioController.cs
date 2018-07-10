using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Cooperchip.MedicalManagement.Domain.Entidade;
using Cooperchip.MedicalManagement.Infra.Data;
using Cooperchip.MedicalManagement.Web.ViewModel;

namespace Cooperchip.MedicalManagement.Web.Controllers
{
    /// <summary>
    ///
    /// </summary>
    public class ProntuarioController : Controller
    {
        private MedicalManagementDbContext db = new MedicalManagementDbContext();


        #region: Cid - Busca-select2

        //GetCidAdaptadas
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCid(string q, int? page)
        {
            ICollection<CidAdaptada> cid = null;
            if (!string.IsNullOrEmpty(q))
            {
                cid = (from c in db.CidAdaptada select c).Where(x => x.Diagnostico.Contains(q)).ToList();
                return Json(new { items = cid }, JsonRequestBehavior.AllowGet);
            }
            cid = (from c in db.CidAdaptada select c).ToList();
            return Json(new { items = cid }, JsonRequestBehavior.AllowGet);
        }

        #endregion:

        #region: Paciente - Busca-select2

        // --------------------------------------------------------------------------------------------- //
        // -----/   Paciente  -------------------------------------------------------------------------- //


        /// <summary>
        /// Usado para busca de paciente
        /// através do plugin select2 em libCooperchip;
        /// </summary>
        /// <returns></returns>
        public JsonResult getPaciente(string q, int? page)
        {
            // Criei, mas ainda não estou usando... ???
            //var paciente = new Paciente();
            //var pacienteView = Mapper.Map<Paciente, PacienteViewModel>(paciente);

            ICollection<Paciente> pac = null;
            if (!string.IsNullOrEmpty(q))
            {
                pac = (from p in db.Paciente select p).Where(x => x.PessoaFisica.NomeOuRazaoSocial.Contains(q)).ToList();
                return Json(new { items = pac }, JsonRequestBehavior.AllowGet);
            }
            pac = (from p in db.Paciente select p).ToList();
            return Json(new { items = pac }, JsonRequestBehavior.AllowGet);
        }

        #endregion:

        #region: Medicamento - Busca-select2
        // --------------------------------------------------------------------------------------------- //
        // --------------------------------------------------------------------------------------------- //
        // -----/   select2 Medicamentos  ----------------------------------------------------------- //

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public JsonResult GetMedicamentosSelect2(string q, int? page)
        {
            ICollection<Medicamento> med = null;
            if (!string.IsNullOrEmpty(q))
            {
                med = (from c in db.Medicamento select c).Where(x => x.Descricao.Contains(q)).ToList();
                return Json(new { items = med }, JsonRequestBehavior.AllowGet);
            }
            med = (from c in db.Medicamento select c).ToList();
            return Json(new { items = med }, JsonRequestBehavior.AllowGet);
        }

        #endregion:

        #region: GetMedicamentosAjusteInteracao
        /// <summary>
        /// 
        /// </summary>
        /// <param name="q"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public JsonResult GetMedicamentosAjusteInteracao(string q, int? page)
        {
            ICollection<Medicamento> med = null;
            if (!string.IsNullOrEmpty(q))
            {
                med = (from c in db.Medicamento select c).Where(x => x.Descricao.Contains(q)).ToList();
                return Json(new { items = med }, JsonRequestBehavior.AllowGet);
            }
            med = (from c in db.Medicamento select c).ToList();
            return Json(new { items = med }, JsonRequestBehavior.AllowGet);
        }
        #endregion:

        #region: InteracaoMedicamentosa Genéricos - Busca-select2
        // --------------------------------------------------------------------------------------------- //
        // --------------------------------------------------------------------------------------------- //
        // -----/   select2 GetDescricaoParaGenericos  --------------------------------------------- //

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDescricaoParaGenericos(string q, int? page)
        {
            ICollection<Generico> gen = null;
            if (!string.IsNullOrEmpty(q))
            {
                gen = (from c in db.Generico select c).Where(x => x.Descricao.Contains(q)).ToList();
                return Json(new { items = gen }, JsonRequestBehavior.AllowGet);
            }
            gen = (from c in db.Generico select c).ToList();
            return Json(new { items = gen }, JsonRequestBehavior.AllowGet);
        }

        #endregion:        

        #region: GetPosologiaPorMedicamento - select2

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetPosologiaPorMedicamento(int id)
        {
            var posologias = (from pos in db.MedicamentoPosologia select pos).Where(x => x.IdMedicamento == id).ToList();
            return Json(posologias, JsonRequestBehavior.AllowGet);
        }

        #endregion:

        #region: Prontuario

        // --------------------------------------------------------------------------------------------- //
        // --------------------------------------------------------------------------------------------- //
        // -----/   Prontuário  ------------------------------------------------------------------------ //


        /// <summary>
        /// Id do paciente, pois é para listar os
        /// prontuários dos pacientes cujo id seja o recebido.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Esse Id é do Paciente</returns>
        public ActionResult ListaProntuario(Guid? id)
        {
            /*
             * Se o Paciente tem Prontuario:
             *      >> Carrega a lista dos prontuario do paciente para edição ou novo prontuario para este paciente;
             * Se o Paciente não tem prontuario:
             *      >> Carrega a tela para cadastramento de uma novo prontuario com NumPrescricao = '0000000', que será filtrada na lista dos pacientes;
             * Se o id for null;
             *      >> Carrega todas os prontuarios de todos os pacientes, pois a chamada vem do menu de prontuario ou do menu principal;
             */
            var prontuarios = new List<Prontuario>();
            if (id == null)
            {
                prontuarios = (from p in db.Prontuario select p).OrderByDescending(x => x.DataProntuario).ToList();
                return View(prontuarios);
            }
            else
            {
                prontuarios = (from p in db.Prontuario select p).Where(x => x.PacienteId == id).OrderByDescending(x => x.DataProntuario).ToList();
                if (prontuarios.Count > 0)
                {
                    return View(prontuarios);
                }
                else
                {
                    /*
                     Neste caso não haveria necessidade de se gerar um novo Guid
                     ou poderia se aproveitar do Guid gerado aqui em CriarNovoProntuario.
                     O mesmo se aplica a Prescrição, mas por enquanto fica assim, pois
                     Não atrapalha, apenas gero um Guid a mais, que não é utilizado nesta implementação!
                    */

                    prontuarios = new List<Prontuario>();

                    // ProntuarioId e DataProntuario gerados do construtor;
                    Prontuario prontuario = new Prontuario()
                    {
                        NumAtendimento = "0000000",
                        PacienteId = (Guid)id,
                        Paciente = (from p in db.Paciente select p).Where(x => x.PacienteId == id).SingleOrDefault()
                    };
                    prontuarios.Add(prontuario);
                    return View(prontuarios);
                }
            }

        }

        #endregion:

        #region: Prontuario Base


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult MakeNewProntuario()
        {
            ProntuarioBase pront = new ProntuarioBase();
            return Json(pront, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Id do paciente, pois é para listar os
        /// prontuários dos pacientes cujo id seja o recebido.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Esse Id é do Paciente</returns>
        public ActionResult ListaProntuarioBase(Guid? id)
        {

            var prontuarios = new List<ProntuarioBase>();
            if (id == null)
            {
                prontuarios = (from p in db.ProntuarioBase select p).OrderByDescending(x => x.DataProntuario).ToList();
                return View(prontuarios);
            }
            else
            {
                prontuarios = (from p in db.ProntuarioBase select p).Where(x => x.PacienteId == id).OrderByDescending(x => x.DataProntuario).ToList();
                return View(prontuarios);
            }
        }

        #endregion:

        #region: Sinais Vitais

        // --------------------------------------------------------------------------------------------- //
        // --------------------------------------------------------------------------------------------- //
        // -----/   Sinais Vitais  --------------------------------------------------------------------- //

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idpc"></param>
        /// <param name="idpt"></param>
        /// <returns></returns>
        public JsonResult GetSinaisVitaisPorId(Guid idpc, Guid idpt)
        {
            var sinalvital = (from s in db.SinaisVitais select s).Where(x => x.PacienteId == idpc && x.ProntuarioGuid == idpt).ToList();
            return Json(sinalvital, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="sinalvital"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddSinaisVitais(SinaisVitais sinalvital)
        {
            if (ModelState.IsValid)
            {
                db.SinaisVitais.Add(sinalvital);
                db.SaveChanges();
            }
            return Json(sinalvital, JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DelSinaisVitais(int id)
        {
            SinaisVitais sinalvital = db.SinaisVitais.Find(id);
            if (ModelState.IsValid)
            {
                db.SinaisVitais.Remove(sinalvital);
                db.SaveChanges();
            }
            return Json(sinalvital, JsonRequestBehavior.AllowGet);
        }

        #endregion:

        #region: Balanço Hídrico

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult GetBalancoHidrico()
        {
            var balancohidrico = (from b in db.BalancoHidrico select b).ToList();
            return Json(balancohidrico, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idpc"></param>
        /// <param name="idpt"></param>
        /// <returns></returns>
        public JsonResult GetBalancoHidricoPorId(Guid idpc, Guid idpt)
        {
            var bh = (from p in db.BalancoHidrico select p).Where(x => x.PacienteId == idpc && x.ProntuarioGuid == idpt).ToList();
            return Json(bh, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bhidrico"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddBalancoHidrico(BalancoHidrico bhidrico)
        {
            if (ModelState.IsValid)
            {
                db.BalancoHidrico.Add(bhidrico);
                db.SaveChanges();
            }
            return Json(bhidrico, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DelBalancoHidrico(int id)
        {
            BalancoHidrico bhidrico = db.BalancoHidrico.Find(id);
            db.BalancoHidrico.Remove(bhidrico);
            db.SaveChanges();
            return Json(bhidrico, JsonRequestBehavior.AllowGet);
        }

        #endregion:

        #region: ApresentacaoAjustesInteracao

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetMedicamentosPosologia(int? id)
        {
            var medicamentoposologia = (from m in db.MedicamentoPosologia
                                        .Include("Medicamento")
                                        select m).Where(x => x.IdMedicamento == id).ToList();
            return Json(medicamentoposologia, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetApresentacoesPorId(int id)
        {
            var medic = (from m in db.MedicamentoApresentacao
                         .Include("Medicamento")
                         select m).Where(x => x.IdMedicamento == id).ToList();
            return Json(medic, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idpc"></param>
        /// <param name="idpt"></param>
        /// <returns></returns>
        public JsonResult GetApresentacaoAjusteInteracaoPorId(Guid idpc, Guid idpt)
        {

            var apajint = new List<ApresentacaoAjusteInteracao>();
            apajint = (from p in db.ApresentacaoAjusteInteracao
                       .Include("Paciente")
                       .Include("Medicamento")
                       .Include("MedicamentoPosologia")
                       select p).Where(x => x.PacienteId == idpc && x.ProntuarioGuid == idpt).ToList();

            return Json(apajint, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="apr"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddApresentacaoAjusteInteracao(ApresentacaoAjusteInteracao apr)
        {
            var idge = apr.IdGenerico;
            var idpc = apr.PacienteId;
            var idpt = apr.ProntuarioGuid;

            var intApresAjusteInteracoes = (from tr in db.ApresentacaoAjusteInteracao select tr).Where(x => x.IdGenerico == idge && x.PacienteId == idpc && x.ProntuarioGuid == idpt).Count();

            if (intApresAjusteInteracoes > 0)
            {
                apr = null;
                ModelState.AddModelError("error_generic_add", "Genérico já Adicionado!");
            }

            if (ModelState.IsValid)
            {
                db.ApresentacaoAjusteInteracao.Add(apr);
                db.SaveChanges();
            }

            return Json(apr, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DelApresentacaoAjusteInteracao(int id)
        {
            ApresentacaoAjusteInteracao apr = db.ApresentacaoAjusteInteracao.Find(id);
            db.ApresentacaoAjusteInteracao.Remove(apr);
            db.SaveChanges();
            return Json(apr, JsonRequestBehavior.AllowGet);
        }

        #endregion:

        #region: Disposing

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

        #endregion:

    }
}
