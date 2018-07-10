using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class Precaucao
    {
        [Key]
        public int PrecaucaoId { get; set; }

        [Required(ErrorMessage = "Precaução é campo obrigatório!")]
        [Display(Name = "Precaução")]
        [MaxLength(80, ErrorMessage = "Máximo de caractere permitido: 80.")]
        [MinLength(2, ErrorMessage = "Mínimo de caractere permitido: é 2.")]
        public string Descricao { get; set; }

        [Required]
        [ForeignKey("TipoDePrecaucao")]
        public int IdTipoPrecaucao { get; set; }

        public virtual TipoDePrecaucao TipoDePrecaucao { get; set; }

    }
}
