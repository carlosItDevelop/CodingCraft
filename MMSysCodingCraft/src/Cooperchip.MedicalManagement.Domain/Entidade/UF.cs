using System.ComponentModel.DataAnnotations;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class Uf
    {

        [Key]
        public int UfId { get; set; }

        [Display(Name = "Sigla")]
        [Required(ErrorMessage = "Descrição da UF é obrigatória!")]
        [MaxLength(2, ErrorMessage = "Máximo de caractere permitido igual a 2.")]
        public string Sigla { get; set; }


        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Estado é obrigatória!")]
        [MaxLength(40, ErrorMessage = "Máximo de caractere permitido igual a 40.")]
        public string Estado { get; set; }



        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código da UF é obrigatória!")]
        public int CodigoEstado { get; set; }

    }
}
