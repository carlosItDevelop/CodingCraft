using System.ComponentModel.DataAnnotations;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class CidAdaptada
    {
        [Key]
        [Display(Name = "ID")]
        public int CidAdaptadaId { get; set; }


        [Display(Name = "Código CID")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(5,ErrorMessage = "Máximo de Caractere permitido: 5")]
        public string Codigo { get; set; }


        [Display(Name = "Diagnóstico")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(300, ErrorMessage = "Máximo de Caractere permitido: 300")]
        public string Diagnostico { get; set; }

    }
}
