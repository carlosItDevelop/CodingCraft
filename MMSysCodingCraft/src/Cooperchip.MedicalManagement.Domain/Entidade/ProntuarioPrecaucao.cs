using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class ProntuarioPrecaucao
    {
        [Key]
        public int ProntuarioPrecaucaoId { get; set; }

        [Required(ErrorMessage = "Causa da Precaução é campo obrigatório!")]
        [Display(Name = "Causa da Precaução")]
        [ForeignKey("Precaucao")]
        public int IdPrecaucao { get; set; }

        [Required]
        [Display(Name = "Tipo de Precaução")]
        [ForeignKey("TipoDePrecaucao")]
        public int IdTipoPrecaucao { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Paciente")]
        [ForeignKey("Paciente")]
        public Guid PacienteId { get; set; }


        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Prontuário")]
        [ForeignKey("Prontuario")]
        public Guid ProntuarioGuid { get; set; }


        public virtual TipoDePrecaucao TipoDePrecaucao { get; set; }
        public virtual Precaucao Precaucao { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual Prontuario Prontuario { get; set; }

    }
}
