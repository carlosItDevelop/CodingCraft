using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class NotificacoesProntuario
    {
        public NotificacoesProntuario()
        {

        }

        [Key]
        [Display(Name = "ID da Notificação")]
        public Guid NotificacoesProntuarioId { get; set; }

        [Required]
        [Display(Name = "Notificções de prontuário")]
        [DataType(DataType.DateTime)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(65, ErrorMessage = "Máximo de Caracteres permitido: 65.")]
        public string Mensagem { get; set; }

        [MaxLength(1000, ErrorMessage = "Máximo de caracteres permitido: 1000.")]
        public string Link { get; set; }
    }
}
