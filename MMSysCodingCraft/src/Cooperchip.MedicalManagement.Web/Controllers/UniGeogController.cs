using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Cooperchip.MedicalManagement.Domain.Entidade;
using Cooperchip.MedicalManagement.Infra.Data;
using PagedList;

namespace Cooperchip.MedicalManagement.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class UniGeogController : Controller
    {
        private MedicalManagementDbContext db = new MedicalManagementDbContext();



        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagina"></param>
        /// <param name="ordenacao"></param>
        /// <param name="busca"></param>
        /// <param name="filtroAtual"></param>
        /// <param name="campo"></param>
        /// <returns></returns>
        public ActionResult Listar(int? pagina, string ordenacao, string filtroAtual, string busca, string campo)
        {


            var q = db.UnidadeGeografica.AsQueryable();

            ViewBag.Ordenacao = ordenacao;

            // Montar os Links na Lista
            ViewBag.SortCep = string.IsNullOrEmpty(ordenacao) ? "Cep" : "";
            ViewBag.SortRua = ordenacao == "Logradouro" ? "Logradouro_Desc" : "Logradouro";
            ViewBag.SortLocal = ordenacao == "Local" ? "Local_Desc" : "Local";
            
            ViewBag.Pagina = pagina;


            if (busca != null)
            {
                if(pagina == null)
                {
                    ViewBag.Pagina = 1;
                }
            } else
            {
                ViewBag.Pagina = pagina ?? 1;
                busca = filtroAtual;
            }

            ViewBag.filtroAtual = busca;
            ViewBag.Campo = campo;

            ViewBag.Selected = "Cep";
            if (!string.IsNullOrEmpty(campo))
            {
                ViewBag.Selected = campo;
            }

            switch (ordenacao)
            {
                case "Cep":
                    q = q.OrderBy(x => x.Cep);
                    break;
                case "Logradouro":
                    q = q.OrderBy(x => x.Logradouro);
                    break;
                case "Logradouro_Desc":
                    q = q.OrderByDescending(x => x.Logradouro);
                    break;
                case "Local":
                    q = q.OrderBy(x => x.Local);
                    break;
                case "Local_Desc":
                    q = q.OrderByDescending(x => x.Local);
                    break;
                default:
                    q = q.OrderBy(x => x.Logradouro);
                    break;
            }



            if (!string.IsNullOrEmpty(busca))
            {
                if(campo == "Cep")
                {
                    q = q.Where(n => n.Cep.Contains(busca));
                } else if (campo == "Rua")
                {
                    q = q.Where(x => x.Logradouro.ToUpper().Contains(busca.ToUpper()));
                } else if (campo == "Local")
                {
                    q = q.Where(x => x.Local.ToUpper().Contains(busca.ToUpper()));
                }
            }


            int tamanhoPagina = 7;
            int numeroPagina = pagina ?? 1;

            if (Request.IsAjaxRequest())
                return PartialView("_PartialListar", q.ToPagedList(numeroPagina, tamanhoPagina));



            return View(q.ToPagedList(numeroPagina, tamanhoPagina));

        }


        /// <summary>
        /// Método para Teste Unitário!
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        public int Soma(int num1, int num2)
        {
            int total = num1 + num2;
            return total;
        }


        // GET: UniGeog/Details/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadeGeografica unidadeGeografica = await db.UnidadeGeografica.FindAsync(id);
            if (unidadeGeografica == null)
            {
                return HttpNotFound();
            }
            return View(unidadeGeografica);
        }

        // GET: UniGeog/Create
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        // POST: UniGeog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unidadeGeografica"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]       
        public async Task<ActionResult> Create(UnidadeGeografica unidadeGeografica)
        {
            if (ModelState.IsValid)
            {
                db.UnidadeGeografica.Add(unidadeGeografica);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(unidadeGeografica);
        }

        // GET: UniGeog/Edit/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadeGeografica unidadeGeografica = await db.UnidadeGeografica.FindAsync(id);
            if (unidadeGeografica == null)
            {
                return HttpNotFound();
            }
            return View(unidadeGeografica);
        }

        // POST: UniGeog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unidadeGeografica"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UnidadeGeografica unidadeGeografica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unidadeGeografica).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(unidadeGeografica);
        }

        // GET: UniGeog/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadeGeografica unidadeGeografica = await db.UnidadeGeografica.FindAsync(id);
            if (unidadeGeografica == null)
            {
                return HttpNotFound();
            }
            return View(unidadeGeografica);
        }

        // POST: UniGeog/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UnidadeGeografica unidadeGeografica = await db.UnidadeGeografica.FindAsync(id);
            db.UnidadeGeografica.Remove(unidadeGeografica);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
