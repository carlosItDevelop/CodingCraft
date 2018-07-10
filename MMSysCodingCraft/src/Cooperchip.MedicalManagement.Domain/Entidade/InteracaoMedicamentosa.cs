using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class InteracaoMedicamentosa
    {
        [Key]
        public int InteracaoMedicamentosaId { get; set; }

        [ForeignKey("Generico")]
        public int IdMedicamentoA { get; set; }


        [ForeignKey("Generico1")]
        public int IdMedicamentoB { get; set; }

        [Display(Name = "Interação/Efeito")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(4000, ErrorMessage = "4.000 caracteres permitidos!")]
        public string Interacao { get; set; }

        public virtual Generico Generico { get; set; }
        public virtual Generico Generico1 { get; set; }

    }
}
