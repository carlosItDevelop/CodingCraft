using System.ComponentModel.DataAnnotations;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class Parametro
    {
        public int ParametroId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres permitidos!")]
        public string Descricao { get; set; }

        [Required]
        public double Minimo { get; set; }

        [Required]
        public double Maximo { get; set; }
    }
}
