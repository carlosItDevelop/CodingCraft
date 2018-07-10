using System.ComponentModel.DataAnnotations;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class EstadoDoPaciente
    {
        [Key]
        [Display(Name = "ID")]
        public int EstadoDoPacienteId { get; set; }


        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Estado do Paciente")]
        public string Descricao { get; set; }
    }
}
