
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class ExameDeImagem
    {
        [Key]
        public int ExameDeImagemId { get; set; }

        [ForeignKey("Paciente")]
        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public Guid PacienteId { get; set; }

        [ForeignKey("Prontuario")]
        [Display(Name = "Prontuario")]
        [Required(ErrorMessage = "Campo Obrigatório.")]
        public Guid ProntuarioGuid { get; set; }
 
        [Display(Name = "Exame")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [MaxLength(40, ErrorMessage = "Máximo de 40 caracteres permitidos.")]
        public string Exame { get; set; }

        [Display(Name = "Pedido em:")]
        [DataType(DataType.Date, ErrorMessage = "Data Inválida.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PedidoEm { get; set; }

        [Display(Name = "Realizada em:")]
        [DataType(DataType.Date, ErrorMessage = "Data Inválida.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? RealizadoEm { get; set; }

        [Display(Name = "Laudo Essencial")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [MaxLength(150, ErrorMessage = "Máximo de 150 caracteres permitidos.")]
        public string LaudoEssencial { get; set; }

        public virtual Paciente Paciente { get; set; }
        public virtual Prontuario Prontuario { get; set; }

    }
}
