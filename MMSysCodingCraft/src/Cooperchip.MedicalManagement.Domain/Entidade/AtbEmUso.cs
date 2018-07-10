using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class AtbEmUso
    {
        [Key]
        public int AtbEmUsoId { get; set; }


        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Descrição é campo obrigatório.")]
        [MaxLength(50, ErrorMessage = "Máximo de caractere é 50.")]
        [MinLength(2, ErrorMessage = "Mínimo de caractere é 2.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data do Início")]
        public DateTime DataInicio { get; set; }


        [ForeignKey("Paciente")]
        [Display(Name = "Paciente ID")]
        [Required(ErrorMessage = "Campo Paciente é Obrigatório!")]
        public Guid PacienteId { get; set; }


        [ForeignKey("Prontuario")]
        [Display(Name = "Prontuário ID")]
        [Required(ErrorMessage = "Campo Prontuário é Obrigatório!")]
        public Guid ProntuarioGuid { get; set; }

        public virtual Paciente Paciente { get; set; }
        public virtual Prontuario Prontuario { get; set; }


    }
}
