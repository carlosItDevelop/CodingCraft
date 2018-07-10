using System.ComponentModel.DataAnnotations;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class Convenio
    {
        public Convenio()
        {
                
        }

        [Key]
        public int  ConvenioId { get; set; }

        [Required(ErrorMessage = "Convênio é obrigatório!")]
        [Display(Name = "Convênio")]
        [MaxLength(50, ErrorMessage = "Máximo de caracteres para convênio é de 50.")]
        [MinLength(2, ErrorMessage = "Mínimo de caracteres para convênio é de 2.")]
        public string Descricao { get; set; }


    }
}
