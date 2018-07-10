using System.ComponentModel.DataAnnotations;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class Fisioterapia
    {
        [Key]
        public int FisioterapiaId { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [MaxLength(35, ErrorMessage = "Máximo de caracteres: 35.")]
        [MinLength(2, ErrorMessage = "Mínimo de caracteres: 2.")]
        public string Descricao { get; set; }

    }
}
