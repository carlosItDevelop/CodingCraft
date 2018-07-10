using System.ComponentModel.DataAnnotations;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class TabelasBase
    {
        [Key]
        [Display(Name = "Id da Tabela")]
        public int TabelasBaseId { get; set; }

        [Required(ErrorMessage = "Nome da Tabela é obrigatório!")]
        [Display(Name = "Nome da Tabela")]
        [MaxLength(40, ErrorMessage = "Máximo de caracteres permitidos: 40")]
        [MinLength(2, ErrorMessage = "Mínimo de caracteres permitidos: 2")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descrição da Tabela é obrigatório!")]
        [Display(Name = "Descrição")]
        [MaxLength(70, ErrorMessage = "Máximo de caracteres permitidos: 70")]
        [MinLength(3, ErrorMessage = "Mínimo de caracteres permitidos: 3")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Action a ser chamada")]
        [MaxLength(60, ErrorMessage = "Máximo de caracteres permitidos: 60")]
        [MinLength(2, ErrorMessage = "Mínimo de caracteres permitidos: 2")]
        public string Action { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Controller a ser chamado")]
        [MaxLength(60, ErrorMessage = "Máximo de caracteres permitidos: 60")]
        [MinLength(2, ErrorMessage = "Mínimo de caracteres permitidos: 2")]
        public string Controller { get; set; }


        [Display(Name = "Exibir?")]
        public bool Ativa { get; set; }



    }
}
