using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class MedicamentoApresentacao
    {
        [Key]
        public int MedicamentoApresentacaoId { get; set; }

        [Required]
        [MaxLength(800)]
        public string Descricao { get; set; }

        [ForeignKey("Medicamento")]
        [Required]
        public int IdMedicamento { get; set; }

        public virtual Medicamento Medicamento { get; set; }
    }
}
