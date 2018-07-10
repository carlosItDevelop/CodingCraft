using System.ComponentModel.DataAnnotations;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class Cidade
    {
        [Key]
        public int CidadeId { get; set; }


        [Required(ErrorMessage = "Cidade é campo obrigatório!")]
        [MaxLength(35, ErrorMessage = "Máximo de caractere para Cidade é de 35.")]
        [MinLength(2, ErrorMessage = "Mínimo de caractere para Cidade é de 2.")]
        [Display(Name = "Cidade")]
        public string Descricao { get; set; }


        [Required]
        [Display(Name = "Id da UF")]
        public int IdUf { get; set; }

    }
}
