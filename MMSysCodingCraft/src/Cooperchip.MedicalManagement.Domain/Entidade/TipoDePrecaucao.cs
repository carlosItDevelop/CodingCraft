using System.ComponentModel.DataAnnotations;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class TipoDePrecaucao
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Descrição")]
        [Required(ErrorMessage ="Campo Obrigatório!")]
        [MaxLength(10)]
        public string Descricao { get; set; }
    }
}
