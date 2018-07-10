using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class MedicamentoPosologia
    {
        [Key]
        public int MedicamentoPosologiaId { get; set; }

        [Required]
        [MaxLength(300)]
        public string Descricao { get; set; }

        [ForeignKey("Medicamento")]
        [Required]
        public int IdMedicamento { get; set; }

        public virtual Medicamento Medicamento { get; set; }
    }
}
