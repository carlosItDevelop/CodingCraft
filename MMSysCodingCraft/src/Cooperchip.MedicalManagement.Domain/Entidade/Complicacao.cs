using System.ComponentModel.DataAnnotations;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class Complicacao
    {
        [Key]
        [Display(Name = "Complicação ID")]
        public int ComplicacaoId { get; set; }

        [Display(Name = "Complicação")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [MaxLength(80, ErrorMessage = "Máximo de caracteres: 80.")]
        [MinLength(2, ErrorMessage = "Máximo de caracteres: 2.")]
        public string Descricao { get; set; }

    }
}
