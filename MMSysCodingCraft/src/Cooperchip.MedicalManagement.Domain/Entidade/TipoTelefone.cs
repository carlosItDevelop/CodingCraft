using System.ComponentModel.DataAnnotations;

namespace Cooperchip.MedicalManagement.Domain.Entidade {
    public class TipoTelefone {
        [Key]
        public int TipoTelefoneId { get; set; }

        [Display(Name="Tipo de Telefone")]
        [Required(ErrorMessage="Tipo de Telefone é obrigatório!")]
        [MaxLength(12, ErrorMessage="Número máximo de caractere é igual a 12")]
        public string Descricao { get; set; }
        
    }
}
