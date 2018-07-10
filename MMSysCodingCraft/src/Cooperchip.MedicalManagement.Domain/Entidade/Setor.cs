using System.ComponentModel.DataAnnotations;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class Setor
    {
        [Key]
        public int SetorId { get; set; }

        [Required]
        [MaxLength(4)]
        public string Sigla { get; set; }

        [Required]
        [MaxLength(35)]
        public string Descricao { get; set; }
    }
}
