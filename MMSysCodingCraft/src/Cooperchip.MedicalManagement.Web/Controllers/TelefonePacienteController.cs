using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Cooperchip.MedicalManagement.Domain.Entidade;
using Cooperchip.MedicalManagement.Infra.Data;
using System;

namespace Cooperchip.MedicalManagement.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class TelefonePacienteController : Controller
    {
        private MedicalManagementDbContext db = new MedicalManagementDbContext();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult GetTelefonePaciente()
        {
            var telefonepaciente = (from b in db.TelefonePaciente select b).ToList();
            return Json(telefonepaciente, JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetTelefonePacientePorId( Guid id )
        {

            List<TelefonePaciente> tel = 
                (from t in db.TelefonePaciente select t).Where(x => x.PacienteId == id).ToList();
            return Json(tel, JsonRequestBehavior.AllowGet);
        }


        //AddTelefonePaciente
        /// <summary>
        /// 
        /// </summary>
        /// <param name="telefonepaciente"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddTelefonePaciente( TelefonePaciente telefonepaciente )
        {
            if ( ModelState.IsValid )
            {
                db.TelefonePaciente.Add(telefonepaciente);
                db.SaveChanges();
            }
            return Json(telefonepaciente, JsonRequestBehavior.AllowGet);
        }

        // POST: //DelTelefonePaciente/n
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DelTelefonePaciente( int id )
        {
            TelefonePaciente telefonepaciente = db.TelefonePaciente.Find(id);
            if (telefonepaciente != null)
            {
                db.TelefonePaciente.Remove(telefonepaciente);
                db.SaveChanges();
            }
            return Json(telefonepaciente, JsonRequestBehavior.AllowGet);
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
