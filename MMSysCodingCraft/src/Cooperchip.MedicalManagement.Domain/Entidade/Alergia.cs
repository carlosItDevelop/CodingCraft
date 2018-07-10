using System.ComponentModel.DataAnnotations;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class Alergia
    {

        [Key]
        public int AlergiaId { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Alergia")]
        [MaxLength(30, ErrorMessage = "Máximo de caractere: 30.")]
        public string Descricao { get; set; }

    }
}
