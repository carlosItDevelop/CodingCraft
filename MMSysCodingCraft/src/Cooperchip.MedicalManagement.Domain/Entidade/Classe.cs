using System.ComponentModel.DataAnnotations;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class Classe
    {
        [Key]
        public int ClasseId { get; set; }

        [Display(Name = "Classe")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [MaxLength(60, ErrorMessage = "Máximo de 60 caracteres.")]
        public string Descricao { get; set; }
    }
}
