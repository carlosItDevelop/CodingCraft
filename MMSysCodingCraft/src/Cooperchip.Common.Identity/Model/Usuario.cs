using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cooperchip.Common.Identity.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Usuario : IdentityUser
    {
        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "Campo Nome é Obrigatório!")]
        [MaxLength(35, ErrorMessage = "Máximo de caracteres permitidos: 35")]
        public string NomeCompleto { get; set; }

        [MaxLength(120, ErrorMessage = "Máximo de caracteres permitidos: 120")]
        public string Facebook { get; set; }

        [Display(Name = "Google+")]
        [MaxLength(120, ErrorMessage = "Máximo de caracteres permitidos: 120")]
        public string Google { get; set; }

        [MaxLength(120, ErrorMessage = "Máximo de caracteres permitidos: 120")]
        public string Twitter { get; set; }

        [MaxLength(120, ErrorMessage = "Máximo de caracteres permitidos: 120")]
        public string Skype { get; set; }

        [MaxLength(15, ErrorMessage = "Máximo de caracteres permitidos, com máscara: 15")]
        public override string PhoneNumber { get; set; }

        [Display(Name = "Sobre o Usuário")]
        public string SobreMim { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        [Required]
        [Display(Name = "Usuário")]
        [MaxLength(16, ErrorMessage = "Máximo de Caracter Permitido: 16")]
        public override string UserName { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Usuario> manager, string authenticationType = "")
        {
            if (string.IsNullOrEmpty(authenticationType))
            {
                authenticationType = DefaultAuthenticationTypes.ApplicationCookie;
            }
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}