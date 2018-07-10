using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class ApresentacaoAjusteInteracao
    {
        [Key]
        public int ApresentacaoAjusteInteracaoId { get; set; }

        [ForeignKey("Medicamento")]
        [Required]
        public int IdMedicamento { get; set; }

        [ForeignKey("MedicamentoPosologia")]
        [Required]
        public int IdPosologia { get; set; }

        [Required]
        public int IdGenerico { get; set; }

        [ForeignKey("Paciente")]
        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "Campo requerido.")]
        public Guid PacienteId { get; set; }

        [ForeignKey("Prontuario")]
        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Prontuário")]
        public Guid ProntuarioGuid { get; set; }

        public virtual Paciente Paciente { get; set; }
        public virtual Prontuario Prontuario { get; set; }

        public virtual Medicamento Medicamento { get; set; }
        public virtual MedicamentoPosologia MedicamentoPosologia { get; set; }

    }
}
