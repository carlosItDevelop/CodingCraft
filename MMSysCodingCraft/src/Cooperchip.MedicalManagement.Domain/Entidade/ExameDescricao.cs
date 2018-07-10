using System.ComponentModel.DataAnnotations;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class ExameDescricao
    {
        [Key]
        public int ExameDescricaoId { get; set; }

        [MaxLength(60, ErrorMessage = "Máximo de 60 caracteres!")]
        public string Exame { get; set; }
    }
}
