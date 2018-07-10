using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class TelefonePaciente
    {

        [Key]
        public int TelefonePacienteId { get; set; }

        [ForeignKey("Paciente")]
        [Required(ErrorMessage = "Id do Paciente é Obrigatório!")]
        public Guid PacienteId { get; set; }


        [Required(ErrorMessage = "DDD é obrigatório!")]
        [MaxLength(2, ErrorMessage = "Número máximo de caracteres são 2")]
        public string Ddd { get; set; }



        [Display(Name = "Número")]
        [Required(ErrorMessage = "Número de Telefone é obrigatório!")]
        [MaxLength(10, ErrorMessage = "Número máximo de caracteres são 10")]
        public string Numero { get; set; }


        [Required(ErrorMessage = "Campo Tipo de telefone é obrigatório!")]
        [Display(Name = "Tipo de Telefone")]
        [MaxLength(30, ErrorMessage = "Máximo de 30 caracteres permitidos!")]
        public string TipoTelefone { get; set; }

        public virtual Paciente Paciente { get; set; }


    }
}
