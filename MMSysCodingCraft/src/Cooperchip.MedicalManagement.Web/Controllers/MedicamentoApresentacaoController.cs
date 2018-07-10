using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Cooperchip.MedicalManagement.Domain.Entidade;
using Cooperchip.MedicalManagement.Infra.Data;

namespace Cooperchip.MedicalManagement.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class MedicamentoApresentacaoController : Controller
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
        public JsonResult GetMedicamentosApresentacao()
        {
            var apres = (from m in db.MedicamentoApresentacao.Include("Medicamento") select m).ToList();
            return Json(apres, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="apres"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddMedicamentoApresentacao(MedicamentoApresentacao apres)
        {
            db.MedicamentoApresentacao.Add(apres);
            db.SaveChanges();
            return Json(apres, JsonRequestBehavior.AllowGet);
        }



        // DelMedicamentosApresentacao
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DelMedicamentosApresentacao(int id)
        {
            MedicamentoApresentacao apres = db.MedicamentoApresentacao.Find(id);
            db.MedicamentoApresentacao.Remove(apres);
            db.SaveChanges();
            return Json(apres, JsonRequestBehavior.AllowGet);
        }


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
    }
}
