using System.ComponentModel.DataAnnotations;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class Dieta
    {
        [Key]
        public int DietaId { get; set; }

        [MaxLength(12,ErrorMessage = "Máximo de caracter permitido: 12.")]
        public string Descricao { get; set; }
    }
}
