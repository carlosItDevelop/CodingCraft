using System.Linq;
using System.Web.Mvc;
using Cooperchip.MedicalManagement.Domain.Entidade;
using Cooperchip.MedicalManagement.Infra.Data;

namespace Cooperchip.MedicalManagement.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class MedicamentoAjustesController : Controller
    {
        private MedicalManagementDbContext db = new MedicalManagementDbContext();

        // GET: MedicamentoAjustes
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
        public JsonResult GetMedicamentosAjuste()
        {
            var ajuste = (from m in db.MedicamentoAjustes.Include("Medicamento") select m).ToList();
            return Json(ajuste, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ajuste"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddMedicamentoAjuste(MedicamentoAjustes ajuste)
        {
            db.MedicamentoAjustes.Add(ajuste);
            db.SaveChanges();
            return Json(ajuste, JsonRequestBehavior.AllowGet);
        }


        //[HttpPost]
        // POST: UdtMedicamentoAjuste

        // DelMedicamentosAjuste
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DelMedicamentosAjuste(int id)
        {
            MedicamentoAjustes ajuste = db.MedicamentoAjustes.Find(id);
            db.MedicamentoAjustes.Remove(ajuste);
            db.SaveChanges();
            return Json(ajuste, JsonRequestBehavior.AllowGet);
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
