using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class Medicamento
    {
        [Key]
        public int MedicamentoId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Descricao { get; set; }

        [MaxLength(100)]
        [Display(Name = "Genérico")]
        [Required]
        public string Generico { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [ForeignKey("Genericos")]
        [Display(Name = "Id genérico")]
        public int IdGenerico { get; set; }

        public virtual Generico Genericos { get; set; }

    }
}
