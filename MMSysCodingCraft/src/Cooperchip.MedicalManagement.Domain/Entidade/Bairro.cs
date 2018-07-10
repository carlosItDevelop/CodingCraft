using System.ComponentModel.DataAnnotations;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class Bairro
    {
        [Key]
        public int BairroId { get; set; }

        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "Campo Bairro é obrigatório!")]
        [MaxLength(60, ErrorMessage = "Máximo de caractere para Bairro é de 60")]
        [MinLength(2, ErrorMessage = "Mínimo de Caractere para Bairro é de 2.")]
        public string Descricao { get; set; }
        
        [Required]
        [Display(Name = "Id da Cidade")]
        public int IdCidade { get; set; }
        
    }
}
