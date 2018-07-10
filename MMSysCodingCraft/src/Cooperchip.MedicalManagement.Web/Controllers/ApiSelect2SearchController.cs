
using System.Web.Http;


namespace Cooperchip.MedicalManagement.Web.Controllers
{

    /// <summary>
    /// APIs de controles de Buscas com a biblioteca Select2
    /// </summary>
    [RoutePrefix("api/v1/evm")]
    public class ApiSelect2SearchController : ApiController
    {


        /*
                #region: Cid - Busca-select2
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

       */

    }
}
