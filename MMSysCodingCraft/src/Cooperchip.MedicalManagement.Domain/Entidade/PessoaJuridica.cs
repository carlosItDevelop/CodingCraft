using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    [Table("PessoaJuridica")]
    public class PessoaJuridica : Pessoa
    {
        [Display(Name = "Razão Social")]
        public override string NomeOuRazaoSocial { get; set; }

        [Display(Name = "Data de Fundação")]
        public override DateTime DataNascimentoOuFundacao { get; set; }

        [Display(Name = "CNPJ")]
        public override string CpfOrCnpj { get; set; }
    }
}
