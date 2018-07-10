using System.ComponentModel.DataAnnotations;

namespace Cooperchip.MedicalManagement.Domain.Entidade {
    public class BaseDeConhecimento 
    {
        [Key]
        public int BaseDeConhecimentoId { get; set; }

        [Required(ErrorMessage="Pergunta é obrigatória!")]
        [MaxLength(150,ErrorMessage="Máximo de caracter é igual a 150.")]
        public string Pergunta { get; set; }

        [Required(ErrorMessage="Resposta é obrigatória!")]
        [MaxLength(250, ErrorMessage="Máximo de caracter é igual a 250.")]
        public string Resposta { get; set; }
    }
}
