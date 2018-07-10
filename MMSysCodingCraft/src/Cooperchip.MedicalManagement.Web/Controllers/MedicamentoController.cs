using System.Linq;
using System.Web.Mvc;
using Cooperchip.MedicalManagement.Domain.Entidade;
using Cooperchip.MedicalManagement.Infra.Data;


namespace Cooperchip.MedicalManagement.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class MedicamentoController : Controller
    {
        private MedicalManagementDbContext db = new MedicalManagementDbContext();

        // GET: Medicamento
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(db.Medicamento.ToList());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult GetMedicamentos()
        {
            var medicamentos = (from m in db.Medicamento select m).ToList();
            return Json(medicamentos, JsonRequestBehavior.AllowGet);
        }


        // POST: AddMedicamento
        /// <summary>
        /// 
        /// </summary>
        /// <param name="medicamento"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddMedicamento(Medicamento medicamento)
        {
            if (ModelState.IsValid)
            {
                db.Medicamento.Add(medicamento);
                db.SaveChanges();
            }
            return Json(medicamento, JsonRequestBehavior.AllowGet);
        }


        // POST: DelMedicamentos
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DelMedicamentos(int? id)
        {
            Medicamento medicamento = db.Medicamento.Find(id);
            if (id != null)
            {
                db.Medicamento.Remove(medicamento);
                db.SaveChanges();
            }
            return Json(medicamento, JsonRequestBehavior.AllowGet);
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
