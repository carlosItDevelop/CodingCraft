using System.ComponentModel.DataAnnotations;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class HistoriaPatologicaPregressa
    {
        [Key]
        public int HistoriaPatologicaPregressaId { get; set; }

        [Required(ErrorMessage="Campo obrigatório!")]
        [Display(Name="Descrição")]
        [MaxLength(80, ErrorMessage="Máximo de caractere é 80.")]
        [MinLength(2, ErrorMessage="Mínimo de caractere é 2.")]        
        public string Descricao { get; set; }
    }
}
