using Cooperchip.MedicalManagement.Domain.Entidade;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Web.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class MedicoViewModel
    {
        [Key]
        public int MedicoId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [MaxLength(80, ErrorMessage = "Máximo de caractere permitido: 80")]
        public string Nome { get; set; }


        [Display(Name = "CRM")]
        [MaxLength(10, ErrorMessage = "Máximo de caractere permitido: 10")]
        public string Crm { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }



        [ForeignKey("Especialidade")]
        [Display(Name = "Especialidade")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public int IdEspecialidade { get; set; }


        public virtual Especialidade Especialidade { get; set; }
    }
}
