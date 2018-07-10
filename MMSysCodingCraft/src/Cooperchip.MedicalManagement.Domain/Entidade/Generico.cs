using System.ComponentModel.DataAnnotations;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class Generico
    {
        [Key]
        public int GenericoId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Descricao")]
        public string Descricao { get; set; }
    }
}
