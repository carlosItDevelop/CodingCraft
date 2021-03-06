﻿using Cooperchip.MedicalManagement.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    [DataContract]
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

        public EstadoCivil EstadoCivil { get; set; }
        public Sexo Sexo { get; set; }

        [IgnoreDataMember]
        public virtual Medico Medico { get; set; }
        [IgnoreDataMember]
        public virtual Paciente Paciente { get; set; }
    }
}
