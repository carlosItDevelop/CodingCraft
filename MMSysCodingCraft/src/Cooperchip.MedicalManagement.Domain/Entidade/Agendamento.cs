using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class Agendamento
    {
        [Key]
        public int AgendamentoId { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [ForeignKey("Paciente")]
        [Display(Name = "Paciente")]
        public Guid PacienteId { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        [MaxLength(5,ErrorMessage = "Máximo de caracteres permitidos: 5")]
        public string Hora { get; set; }

        [MaxLength(1500)]
        public string Exames { get; set; }
        public bool Confirmado { get; set; }

        [Required]
        [ForeignKey("Medico")]
        public Guid MedicoId { get; set; }

        public virtual Medico Medico { get; set; }

        public virtual Paciente Paciente { get; set; }

    }
}
