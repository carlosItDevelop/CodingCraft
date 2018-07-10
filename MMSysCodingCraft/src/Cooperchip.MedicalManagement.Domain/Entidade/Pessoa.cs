using Cooperchip.MedicalManagement.Domain.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    [Table("Pessoa")]
    public class Pessoa : Entidade
    {
        public Pessoa()
        {
            PessoaId = Guid.NewGuid();
        }

        [Key]
        public Guid PessoaId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Nome é campo obrigatório!")]
        public virtual string NomeOuRazaoSocial { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public virtual DateTime DataNascimentoOuFundacao { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [CpfCnpj]
        [StringLength(18)]
        public virtual string CpfOrCnpj { get; set; }

        public bool Ativo { get; set; }
    }
}
