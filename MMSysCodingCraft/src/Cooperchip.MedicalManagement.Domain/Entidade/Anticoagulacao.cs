using System.ComponentModel.DataAnnotations;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class Anticoagulacao
    {
        [Key]
        public int AnticoagulacaoId { get; set; }

        [Required(ErrorMessage="Campo obrigatório!")]
        [Display(Name="Anticoagulação")]
        [MaxLength(20, ErrorMessage="Máximo de caractere permitido é 20.")]
        [MinLength(2, ErrorMessage="Mínimo de caractere permitido é 2.")]
        public string Descricao { get; set; }
    }
}
