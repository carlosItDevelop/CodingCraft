using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class MedicamentoAjustes
    {
        [Key]
        public int MedicamentoAjustesId { get; set; }

        [Required]
        [MaxLength(1500)]
        public string Descricao { get; set; }

        [ForeignKey("Medicamento")]
        [Required]
        public int IdMedicamento { get; set; }

        public virtual Medicamento Medicamento { get; set; }
    }
}
