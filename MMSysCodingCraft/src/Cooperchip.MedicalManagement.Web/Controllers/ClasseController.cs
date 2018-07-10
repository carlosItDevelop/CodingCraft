using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Cooperchip.MedicalManagement.Domain.Entidade;
using Cooperchip.MedicalManagement.Infra.Data;

namespace Cooperchip.MedicalManagement.Web.Controllers
{


    /// <summary>
    /// Controller de gestão de Classe
    /// </summary>
    [RoutePrefix("api/v1/evm")]
    public class ClasseController : ApiController
    {


        private MedicalManagementDbContext db = new MedicalManagementDbContext();

        /// <summary>
        /// Obtem uma coleção de Classe
        /// </summary>
        /// <remarks>Obtem uma coleção completa com todas as Classes</remarks>
        /// <returns></returns>
        [Route("ObterClasse")]
        public IQueryable<Classe> GetClasse()
        {
            return db.Classe;
        }

        /// <summary>
        /// Obtem Classe por Id
        /// </summary>
        /// <remarks>Obtem um objeto Classe, através do parâmetro Id</remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("ObterClassePorId")]
        public HttpResponseMessage GetClasse(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Classe classe = db.Classe.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, classe);
        }

        /// <summary>
        /// Altera um objeto Classe
        /// </summary>
        /// <remarks>Altera um objeto Classe, passando o obteto SEM seu Id</remarks>
        /// <param name="classe"></param>
        /// <returns></returns>
        [Route("AlterarClasse")]
        public HttpResponseMessage PutClasse(Classe classe)
        {
            if (classe == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            db.Entry(classe).State = EntityState.Modified;
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, classe);
        }

        /// <summary>
        /// Adição de Classe
        /// </summary>
        /// <remarks>Cadastra um objeto Classe passando sua Descrição apenas</remarks>
        /// <param name="classe"></param>
        /// <returns></returns>
        [Route("AdicionarClasse")]
        public HttpResponseMessage PostClasse(Classe classe)
        {
            if (classe == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            db.Classe.Add(classe);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, classe);
        }

        /// <summary>
        /// Exclusão de Classe
        /// </summary>
        /// <remarks>Exclusão de Classe através da passagem do parâmetro Id</remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("ExcluirClasse")]
        [ResponseType(typeof(Classe))]
        public HttpResponseMessage DeleteClasse(int id)
        {
            if (id <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Classe classe = db.Classe.Find(id);
            db.Classe.Remove(classe);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, classe);
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
