using System.ComponentModel.DataAnnotations;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class TipoDreno
    {
        [Key]
        public int TipoDrenoId { get; set; }

        [Display(Name="Descrição")]
        [Required]
        [MaxLength(25,ErrorMessage ="Máximo de caracter: 25")]
        public string Descricao { get; set; }
    }
}
