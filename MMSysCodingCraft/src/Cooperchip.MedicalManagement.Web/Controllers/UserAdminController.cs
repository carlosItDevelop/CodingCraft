using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Cooperchip.Common.Identity.Model;
using Cooperchip.Common.Identity.Configuration;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using Cooperchip.Common.Identity.Context;

namespace Cooperchip.MedicalManagement.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize(Roles = "Admin")]
    public class UsersAdminController : Controller
    {

        /// <summary>
        /// 
        /// </summary>
        public UsersAdminController()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="roleManager"></param>
        public UsersAdminController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        private ApplicationUserManager _userManager;
        /// <summary>
        /// 
        /// </summary>
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private ApplicationRoleManager _roleManager;

        /// <summary>
        /// 
        /// </summary>
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }



        private ApplicationDbContext _dbContext;

        /// <summary>
        /// 
        /// </summary>
        public ApplicationDbContext DbContext
        {
            get { return _dbContext ?? HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>(); }
            set { _dbContext = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: ClaimsAdmin
        public ActionResult ListarClaims()
        {
            return View(DbContext.Claims.ToList());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: ClaimsAdmin/SetUserClaim
        public ActionResult SetUserClaim(string id)
        {


            ViewBag.Type = new SelectList
                (
                    DbContext.Claims.ToList(),
                    "Name",
                    "Name"
                );

            ViewBag.User = UserManager.FindById(id);

            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="claim"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: ClaimsAdmin/SetUserClaim
        [HttpPost]
        public ActionResult SetUserClaim(ClaimViewModel claim, string id)
        {
            try
            {
                UserManager.AddClaimAsync(id, new Claim(claim.Type, claim.Value));
                return RedirectToAction("Index", "UsersAdmin", new { id = id });
            }
            catch
            {
                return View("Index");
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: ClaimsAdmin/CreateClaim
        public ActionResult CreateClaim()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="claim"></param>
        /// <returns></returns>
        // POST: ClaimsAdmin/CreateClaim
        [HttpPost]
        public ActionResult CreateClaim(Claims claim)
        {
            //List<string> nomeclaim = null;
            try
            {

                ViewBag.JaTemClaim = "";
                var nomeclaim = (from c in DbContext.Claims select c).Where(x => x.Name == claim.Name).ToList();
                if ((nomeclaim.Count > 0) && (nomeclaim != null))
                {
                    ViewBag.JaTemClaim = "Esta Policy já está Cadastrada!";
                    return RedirectToAction("Index", "UsersAdmin");
                }

                if (ModelState.IsValid)
                {
                    DbContext.Claims.Add(claim);
                    DbContext.SaveChanges();
                }

                return RedirectToAction("Index", "UsersAdmin");
            }
            catch
            {
                ViewBag.JaTemClaim = "Erro ao Cadastrar Policy";
                return View();
            }
        }


        //
        // GET: /Users/
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            return View(await UserManager.Users.ToListAsync());
        }

        //
        // GET: /Users/Details/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByIdAsync(id);

            ViewBag.RoleNames = await UserManager.GetRolesAsync(user.Id);
            ViewBag.Claims = await UserManager.GetClaimsAsync(user.Id);  // Carlos


            return View(user);
        }

        //
        // GET: /Users/Create
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Create()
        {
            //Get the list of Roles
            ViewBag.RoleId = new SelectList(await RoleManager.Roles.ToListAsync(), "Name", "Name");
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Claims(string id) // Carlos
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByIdAsync(id);

            ViewBag.RoleNames = await UserManager.GetRolesAsync(user.Id);
            ViewBag.Claims = await UserManager.GetClaimsAsync(user.Id);  // Carlos


            return View(user);
        }


        // POST: /Users/Create
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userViewModel"></param>
        /// <param name="selectedRoles"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create(RegisterViewModel userViewModel, params string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                var user = new Usuario
                {
                    UserName = userViewModel.Usuario,
                    Email = userViewModel.Email,

                    NomeCompleto = userViewModel.NomeCompleto,
                    Facebook = userViewModel.Facebook,
                    Google = userViewModel.Google,
                    Twitter = userViewModel.Twitter,
                    Skype = userViewModel.Skype,
                    PhoneNumber = userViewModel.Telefone,
                    SobreMim = userViewModel.AboutMe

                };


                var adminresult = await UserManager.CreateAsync(user, userViewModel.Password);

                //Add User to the selected Roles 
                if (adminresult.Succeeded)
                {
                    if (selectedRoles != null)
                    {
                        var result = await UserManager.AddToRolesAsync(user.Id, selectedRoles);
                        if (!result.Succeeded)
                        {
                            ModelState.AddModelError("", result.Errors.First());
                            ViewBag.RoleId = new SelectList(await RoleManager.Roles.ToListAsync(), "Name", "Name");
                            return View();
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", adminresult.Errors.First());
                    ViewBag.RoleId = new SelectList(RoleManager.Roles, "Name", "Name");
                    return View();

                }
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(RoleManager.Roles, "Name", "Name");
            return View();
        }




        //
        // GET: /Users/Edit/1
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByIdAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            var userRoles = await UserManager.GetRolesAsync(user.Id);
            var claimsRoles = await UserManager.GetClaimsAsync(user.Id);  // Carlos


            return View(new EditUserViewModel()
            {
                Id = user.Id,
                Usuario = user.UserName,
                Email = user.Email,

                NomeCompleto = user.NomeCompleto,
                Facebook = user.Facebook,
                Google = user.Google,
                Twitter = user.Twitter,
                Skype = user.Skype,
                Telefone = user.PhoneNumber,
                AboutMe = user.SobreMim,

                RolesList = RoleManager.Roles.ToList().Select(x => new SelectListItem()
                {
                    Selected = userRoles.Contains(x.Name),
                    Text = x.Name,
                    Value = x.Name
                })
            });
        }

        //
        // POST: /Users/Edit/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="editUser"></param>
        /// <param name="selectedRole"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditUserViewModel editUser, params string[] selectedRole)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(editUser.Id);
                if (user == null)
                {
                    return HttpNotFound();
                }

                user.UserName = editUser.Usuario;
                user.Email = editUser.Email;

                user.NomeCompleto = editUser.NomeCompleto;
                user.Facebook = editUser.Facebook;
                user.Google = editUser.Google;
                user.Twitter = editUser.Twitter;
                user.Skype = editUser.Skype;
                user.PhoneNumber = editUser.Telefone;
                user.SobreMim = editUser.AboutMe;

                var userRoles = await UserManager.GetRolesAsync(user.Id);

                selectedRole = selectedRole ?? new string[] { };

                var result = await UserManager.AddToRolesAsync(user.Id, selectedRole.Except(userRoles).ToArray<string>());

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                result = await UserManager.RemoveFromRolesAsync(user.Id, userRoles.Except(selectedRole).ToArray<string>());

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Something failed.");
            return View();
        }

        //
        // GET: /Users/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByIdAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Users/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var user = await UserManager.FindByIdAsync(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                var result = await UserManager.DeleteAsync(user);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
