using Cooperchip.Common.Identity.Model;
using Cooperchip.MedicalManagement.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{

    public class Acesso
    {
        /// <summary>
        /// 
        /// </summary>
        public Acesso()
        {
            this.AcessoId = Guid.NewGuid();
        }

        [Key]
        [Display(Name = "ID")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public Guid AcessoId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Usuário")]
        public Guid IdUsuario { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Tipo de Acesso")]
        public AcessoTipo AcessoTipo { get; set; } // User or Function (Claims or Roles)

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Recurso")]
        [MaxLength(30, ErrorMessage = "Máximo de caracter permitido: 30.")]
        public string Claim { get; set; }

        [Display(Name = "Ler")]
        public bool AllowRead { get; set; }

        [Display(Name = "Atualizar")]
        public bool AllowUpdate { get; set; }

        [Display(Name = "Adicionar")]
        public bool AllowCreate { get; set; }

        [Display(Name = "Excluir")]
        public bool AllowDelete { get; set; }

        [Display(Name = "Acesso Total")]
        public bool AllowAll { get; set; }

    }
}
