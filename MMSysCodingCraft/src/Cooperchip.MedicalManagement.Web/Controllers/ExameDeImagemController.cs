
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
    public class ExameDeImagemController : Controller
    {
        private MedicalManagementDbContext db = new MedicalManagementDbContext();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult GetExameDeImagem()
        {
            var examedeimagem = (from e in db.ExameDeImagem select e).ToList();
            return Json(examedeimagem, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idpc"></param>
        /// <param name="idpt"></param>
        /// <returns></returns>
        public ActionResult GetExameDeImagemPorId(Guid idpc, Guid idpt)
        {
            var examedeimagem = (from e in db.ExameDeImagem select e).Where(x=>x.PacienteId == idpc && x.ProntuarioGuid == idpt).ToList();
            return Json(examedeimagem, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exameimg"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddExameDeImagem(ExameDeImagem exameimg)
        {
            if (ModelState.IsValid)
            {
                db.ExameDeImagem.Add(exameimg);
                db.SaveChanges();
            }
            return Json(exameimg, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DelExameDeImagem(int id)
        {
            ExameDeImagem examedeimagem = db.ExameDeImagem.Find(id);
            db.ExameDeImagem.Remove(examedeimagem);
            db.SaveChanges();
            return Json(examedeimagem, JsonRequestBehavior.AllowGet);
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
