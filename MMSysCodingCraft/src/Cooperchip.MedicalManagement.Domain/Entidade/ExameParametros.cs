using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    /// <summary>
    /// 
    /// </summary>
    public class ExameParametros
    {
        public ExameParametros()
        {
            this.ExameParametrosId = Guid.NewGuid();
        }

        [Key]
        public Guid ExameParametrosId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(50, ErrorMessage = "Máximo de caracter permitido: 50.")]
        public string Exame { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Mínimo Tolerável")]
        public decimal Minimo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Máximo Tolerável")]
        public decimal Maximo { get; set; }

        /// <summary>
        /// (readonly) Método público para se obter o 
        /// Valor ideal de resultado para o exame.
        /// </summary>
        /// <returns></returns>
        public decimal GetValorIdeal() {
            return (this.Maximo + this.Minimo) / 2;
        }

    }
}
