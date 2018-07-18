using Cooperchip.MedicalManagement.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cooperchip.MedicalManagement.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/v1/evm")]
    public class ApiMedicosController : ApiController
    {
        private MedicalManagementDbContext db = new MedicalManagementDbContext();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ObterMedicosViewModel")]
        public HttpResponseMessage GetMedicosVm()
        {
            var medico = db.Medico.Include("Especialidade").Include("PessoaFisica").ToList();
            return Request.CreateResponse(HttpStatusCode.OK, medico);
        }

    }
}
