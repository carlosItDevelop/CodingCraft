using System.ComponentModel.DataAnnotations;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class Leito
    {
        [Key]
        public int LeitoId { get; set; }


        [Display(Name = "Especificação")]
        [MaxLength(15, ErrorMessage = "Máximo de caractere permitido é 15.")]
        public string EspecificacaoDoLeito { get; set; }


    }
}
