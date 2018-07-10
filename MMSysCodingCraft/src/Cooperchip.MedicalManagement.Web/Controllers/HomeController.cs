using System.Linq;
using System.Web.Mvc;
using Cooperchip.MedicalManagement.Domain.Entidade;
using Cooperchip.MedicalManagement.Infra.Data;
using System.Collections.Generic;
using AspNetInterop.UI.MVC5.Permissions;
using System;
using PagedList;
using System.Net;
// ReSharper disable InconsistentNaming

namespace Cooperchip.MedicalManagement.Web.Controllers
{

    /// <summary>
    /// Controle Home: Principal do Sistema de Views
    /// </summary>
    [Authorize]
    //[ClaimsAcesso("AcessoCTI")]
    public class HomeController : Controller
    {

        private MedicalManagementDbContext db = new MedicalManagementDbContext();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult PaginationAngularJS()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Manuais()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult ListaEImagens()
        {
            return View();
        }

        /// <summary>
        /// Chama para a View de usuário Autenticado, mas não autorizado para um Resource;
        /// </summary>
        /// <returns></returns>
        public ActionResult AcessoNegado()
        {
            ViewBag.User = HttpContext.User.Identity.Name;
            return View();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Abertura()  // Subtituída por BoxInit por equanto;
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Icons() 
        {
            return View();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Calendario()
        {
            return View();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult TabsDoTema()
        {
            return View();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult BoxInit()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Erro()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Portais()
        {
            return View();
        }

        // GetEstadoPaciente
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult GetEstadoPaciente()
        {
            var estadopac = (from ep in db.Paciente select ep.EstadoPacienteId).ToList();
            return Json(estadopac, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Buscar(Guid id)
        {
            List<Paciente> pac = (from p in db.Paciente
                                  select p).Where(x => x.PacienteId == id).ToList();
            return Json(pac, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult BuscaPacienteMenuRigthModal(Guid id)
        {
            List<Paciente> pac = (from p in db.Paciente
                                         .Include("Setor")
                                         .Include("Leito")
                                  select p).Where(x => x.PacienteId == id).ToList();

            return Json(pac, JsonRequestBehavior.AllowGet);
        }




        /// <summary>
        /// Busca Endereço para Partial _EndereçoPaciente,
        /// que é utilizada em Prontuario, Prescricao, BHidrico e EImagem!
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult getEndereco(Guid id)
        {
            var end = (from p in db.Endereco
                       select p).Where(x => x.PacienteId == id).FirstOrDefault();
            return Json(end, JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Endereco()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ClaimsAcesso("LerMedico","True")]
        public ActionResult Medico()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult ChamadaMedico()
        {
            return View();
        }

        //ExcluirChamadaMedico
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[ClaimsAcesso("ChamadaMedico", "Excluir")]
        public ActionResult ExcluirChamadaMedico(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChamadaMedico chamada = db.ChamadaMedico.Find(id);
            if (chamada == null)
            {
                return HttpNotFound();
            }
            return View(chamada);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[ClaimsAcesso("ChamadaMedico", "Excluir")]
        [HttpPost, ActionName("ExcluirChamadaMedico")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmExcluirChamadaMedico(int id)
        {
            ChamadaMedico chamada = db.ChamadaMedico.Find(id);
            db.ChamadaMedico.Remove(chamada);
            db.SaveChanges();
            return RedirectToAction("Dashboard","Home");
            //return View();
        }


        //-------------------------------------------------//



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult ExameDeImagem()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Dashboard(/*int? pagechamada*/)
        {
            //int qtdePageChamada = 5;
            //int numeroOfPageChamada = (pagechamada ?? 1);
            //var listaPacientes = db.ChamadaMedico.ToList();
            //return View(listaPacientes.ToPagedList(numeroOfPageChamada, qtdePageChamada));
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Paciente()
        {
            return View();
        }

        // ------------------------------------------------------ //
        // ModalAngularUI

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult ModalAngularUI()
        {
            return View();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult BaseDeConhecimento()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult EstadoDoPaciente()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult InteracaoMedicamentosa()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Bairro()
        {
            return View();
        }





        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Classe()
        {
            return View();
        }

        /// <summary>
        /// Chamada de HistoriaPatologicaPregressa em Home Controller
        /// </summary>
        /// <returns>HistoriaPatologicaPregressa.chtml</returns>
        public ActionResult HistoriaPatologicaPregressa()
        {
            return View();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult CidAdaptada()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Especialidade()
        {
            return View();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Agendamento()
        {
            return View();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult ExameDescricao()
        {
            return View();
        }

        


        // ------------------------------------------------------ //
        // Slides

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Slides()
        {
            return View();
        }




        // ------------------------------------------------------ //
        // Contatos

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Contatos()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult GetContato()
        {
            var contatos = (from c in db.Contato
                            select c).ToList();
            return Json(contatos, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult GetOperadoras()
        {
            var operadora = (from o in db.Operadora
                             select o).ToList();
            return Json(operadora, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cont"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddContato(Contato cont)
        {
            if (ModelState.IsValid)
            {
                db.Contato.Add(cont);
                db.SaveChanges();
            }
            return Json(cont, JsonRequestBehavior.AllowGet);
        }


        // POST: DelContato/DelContato/n
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DelContato(int id)
        {
            Contato contato = db.Contato.Find(id);
            db.Contato.Remove(contato);
            db.SaveChanges();
            return Json(contato, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Poe no lixo a instancia de db
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

    }
}