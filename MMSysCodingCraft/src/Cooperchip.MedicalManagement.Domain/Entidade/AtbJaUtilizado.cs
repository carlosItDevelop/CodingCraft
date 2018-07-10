using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class AtbJaUtilizado
    {
        [Key]
        public int AtbJaUtilizadoId { get; set; }

        [Display(Name="Descrição")]
        [Required(ErrorMessage = "Descrição é campo obrigatório.")]
        [MaxLength(50, ErrorMessage = "Máximo de caractere é 50.")]
        [MinLength(2, ErrorMessage = "Mínimo de caractere é 2.")]
        public string Descricao { get; set; }

        [ForeignKey("Paciente")]
        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "ID do Paciente é campo obrigatório.")]
        public Guid PacienteId { get; set; }


        [ForeignKey("Prontuario")]
        [Display(Name = "Prontuario")]
        [Required(ErrorMessage = "ID do Prontuário é campo obrigatório.")]
        public Guid ProntuarioGuid { get; set; }


        public virtual Paciente Paciente { get; set; }
        public virtual Prontuario Prontuario { get; set; }

    }
}
