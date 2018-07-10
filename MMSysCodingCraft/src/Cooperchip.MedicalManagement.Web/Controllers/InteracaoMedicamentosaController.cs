using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Cooperchip.MedicalManagement.Domain.Entidade;
using Cooperchip.MedicalManagement.Infra.Data;

namespace Cooperchip.MedicalManagement.Web.Controllers
{
    /// <summary>
    /// Controller de gestão de Interação Medicamentosa
    /// </summary>
    [RoutePrefix("api/v1/evm")]
    public class InteracaoMedicamentosaController : ApiController
    {
        private MedicalManagementDbContext db = new MedicalManagementDbContext();


        /// <summary>
        /// Obtem uma coleção de InteracaoMedicamentosa
        /// </summary>
        /// <remarks>Obtem uma coleção completa com todos os InteracaoMedicamentosas</remarks>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ObterInteracaoMedicamentosas")]
        public HttpResponseMessage GetInteracaoMedicamentosa()
        {
            List<InteracaoMedicamentosa> itmd = (from i in db.InteracaoMedicamentosa
                     .Include("Generico") select i).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, itmd);
        }

        /// <summary>
        /// Obtem InteracaoMedicamentosa por Id
        /// </summary>
        /// <remarks>Obtem um objeto InteracaoMedicamentosa, através do parâmetro Id</remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ObterInteracaoMedicamentosaPorId")]
        public HttpResponseMessage GetInteracaoMedicamentosa(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            InteracaoMedicamentosa interacaoMedicamentosa = db.InteracaoMedicamentosa.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, interacaoMedicamentosa);
        }

        /// <summary>
        /// Altera um objeto InteracaoMedicamentosa
        /// </summary>
        /// <remarks>Altera um objeto InteracaoMedicamentosa, passando o obteto SEM seu Id</remarks>
        /// <param name="interacaoMedicamentosa"></param>
        /// <returns></returns>
        //[HttpPut]
        [System.Web.Http.Route("AlterarInteracaoMedicamentosa")]
        public HttpResponseMessage PutInteracaoMedicamentosa(InteracaoMedicamentosa interacaoMedicamentosa)
        {
            if (interacaoMedicamentosa == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            db.Entry(interacaoMedicamentosa).State = EntityState.Modified;
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, interacaoMedicamentosa);
        }

        /// <summary>
        /// Adição de InteracaoMedicamentosa
        /// </summary>
        /// <remarks>Cadastra um objeto InteracaoMedicamentosa passando sua Descrição apenas</remarks>
        /// <param name="interacaoMedicamentosa"></param>
        /// <returns></returns>
        //[HttpPost]
        [System.Web.Http.Route("AdicionarInteracaoMedicamentosa")]
        public HttpResponseMessage PostInteracaoMedicamentosa(InteracaoMedicamentosa interacaoMedicamentosa)
        {
            if (interacaoMedicamentosa == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            db.InteracaoMedicamentosa.Add(interacaoMedicamentosa);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, interacaoMedicamentosa);
        }

        /// <summary>
        /// Exclusão de InteracaoMedicamentosa
        /// </summary>
        /// <remarks>Exclusão de InteracaoMedicamentosa através da passagem do parâmetro Id</remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        //[HttpDelete]
        [System.Web.Http.Route("ExcluirInteracaoMedicamentosa")]
        public HttpResponseMessage DeleteInteracaoMedicamentosa(int id)
        {
            if (id <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            InteracaoMedicamentosa interacaoMedicamentosa = db.InteracaoMedicamentosa.Find(id);
            db.InteracaoMedicamentosa.Remove(interacaoMedicamentosa);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, interacaoMedicamentosa);
        }

        /// <summary>
        /// Realisa um dispose na entidade db
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
