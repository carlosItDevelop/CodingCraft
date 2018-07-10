
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class Dreno
    {
        [Key]
        public int DrenoId { get; set; }

        [ForeignKey("Paciente")]
        [Required(ErrorMessage = "Campo requerido.")]
        public Guid PacienteId { get; set; }

        [ForeignKey("Prontuario")]
        [Display(Name = "Id do Prontuário")]
        [Required(ErrorMessage = "Campo requerido.")]
        public Guid ProntuarioGuid { get; set; }

        [ForeignKey("TipoDreno")]
        [Required]
        public int IdTipoDreno { get; set; }

        [Required]
        [MaxLength(35)]
        public string Local { get; set; }

        public DateTime DataInsercao  { get; set; }

        public virtual TipoDreno TipoDreno { get; set; }

        public virtual Paciente Paciente { get; set; }
        public virtual Prontuario Prontuario { get; set; }
    }
}
