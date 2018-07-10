using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    [Table("PessoaFisica")]
    public class PessoaFisica : Pessoa
    {
        [Display(Name = "Nome")]
        public override string NomeOuRazaoSocial { get; set; }

        [Display(Name = "Data de Nascimento")]
        public override DateTime DataNascimentoOuFundacao { get; set; }

        [Display(Name = "CPF")]
        public override string CpfOrCnpj { get; set; }

        [StringLength(14, ErrorMessage = "Máximo de Caracteres permitidos: {1}")]
        [Display(Name = "RG")]
        public string Rg { get; set; }

        [Display(Name = "Órgão Emissor do RG")]
        [StringLength(10, ErrorMessage = "Máximo de Caracteres permitidos: {1}")]
        public string OrgaoEmissorRg { get; set; }

        [Display(Name = "Data de Emissão do RG")]
        [DataType(DataType.Date, ErrorMessage = "Data Inválida.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataEmissaoRg { get; set; }

        public virtual Medico Medico { get; set; }
        public virtual Paciente Paciente { get; set; }
    }
}
