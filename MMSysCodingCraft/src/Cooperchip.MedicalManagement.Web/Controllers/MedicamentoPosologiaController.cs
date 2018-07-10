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
    public class MedicamentoPosologiaController : Controller
    {
        private MedicalManagementDbContext db = new MedicalManagementDbContext();

        // GET: MedicamentoPosologia
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
        public JsonResult GetMedicamentosPosologia()
        {
            var posologia = (from mp in db.MedicamentoPosologia.Include("Medicamento") select mp).ToList();
            return Json(posologia, JsonRequestBehavior.AllowGet);
        }


        // POST: AddMedicamentoPosologia
        /// <summary>
        /// 
        /// </summary>
        /// <param name="posologia"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddMedicamentoPosologia(MedicamentoPosologia posologia)
        {
            db.MedicamentoPosologia.Add(posologia);
            db.SaveChanges();
            return Json(posologia, JsonRequestBehavior.AllowGet);
        }


        //[HttpPost]
        // POST: UdtMedicamentoPosologia

        // DelMedicamentosPosologia
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DelMedicamentosPosologia(int id)
        {
            MedicamentoPosologia posologia = db.MedicamentoPosologia.Find(id);
            db.MedicamentoPosologia.Remove(posologia);
            db.SaveChanges();
            return Json(posologia, JsonRequestBehavior.AllowGet);
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
