using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class ProntuarioBase
    {
        public ProntuarioBase()
        {
            this.ProntuarioId = Guid.NewGuid();
            this.DataProntuario = DateTime.Now;
            this.NumAtendimento = "0000000";
        }

        [Key]
        public Guid ProntuarioId { get; set; }

        [ForeignKey("Paciente")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Paciente")]
        public Guid PacienteId { get; set; }

        [Display(Name = "Data do Prontuário")]
        [DataType(DataType.Date, ErrorMessage = "Data Inválida.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataProntuario { get; set; }

        [Display(Name = "Nº Atendimento")]
        [Required(ErrorMessage = "Campo requerido.")]
        [MaxLength(10, ErrorMessage = "Máximo de Caracter: 10.")]
        [MinLength(6, ErrorMessage = "Mínimo de Caracter: 6.")]
        public string NumAtendimento { get; set; }

        public virtual Paciente Paciente { get; set; }
    }
}
