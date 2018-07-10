using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class ResultadoExame
    {
        public ResultadoExame()
        {
            this.ResultadoExameId = Guid.NewGuid();
        }

        [Key]
        [Display(Name = "ID")]
        public Guid ResultadoExameId { get; set; }

        [ForeignKey("Paciente")]
        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Paciente")]
        public Guid PacienteId { get; set; }

        [Required]
        [Display(Name = "Nº da Prescrição")]
        public Guid IdPrescricao { get; set; }

        [ForeignKey("ExameParametros")]
        [Required]
        [Display(Name = "Exame-Parâmetro")]
        public Guid IdExameParametros { get; set; }

        [ForeignKey("Medico")]
        [Required]
        [Display(Name = "Pedido por")]
        public Guid MedicoId { get; set; }

        [Required]
        [Display(Name = "Data do Pedido")]
        [DataType(DataType.DateTime)]
        public DateTime PedidoEm { get; set; }

        [Required]
        [Display(Name = "Data do Resultado")]
        [DataType(DataType.DateTime)]
        public DateTime DataResultado { get; set; }


        [Required]
        public decimal Resultado { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        public virtual ExameParametros ExameParametros { get; set; }
        public virtual Medico Medico { get; set; }

        public virtual Paciente Paciente { get; set; }

    }
}
