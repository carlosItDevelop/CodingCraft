using Cooperchip.MedicalManagement.Domain.Entidade;
using Cooperchip.MedicalManagement.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Web.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class MedicoViewModel
    {
        private bool _ativo;

        /*-----/ Campos PessoaFisica ------*/

        [EmailAddress]
        public string Email { get; set; }

        public bool Ativo { get => _ativo; set => _ativo = value; }

        [Display(Name = "Nome")]
        public string NomeOuRazaoSocial { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date, ErrorMessage = "Data Inválida.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimentoOuFundacao { get; set; }

        [Display(Name = "CPF")]
        public string CpfOrCnpj { get; set; }

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

        /*-------/ Campos Medicos ----------*/


        public Guid MedicoId { get; set; }


        [Display(Name = "CRM")]
        [StringLength(10, ErrorMessage = "Máximo de caracteres permitidos: 10")]
        public string Crm { get; set; }



        [Display(Name = "Especialidade")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public int EspecialidadeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="medicoViewModel"></param>
        public static explicit operator PessoaFisica(MedicoViewModel medicoViewModel)
        {
            return new PessoaFisica
            {
                PessoaId = medicoViewModel.MedicoId,
                NomeOuRazaoSocial = medicoViewModel.NomeOuRazaoSocial,
                Ativo = medicoViewModel.Ativo,
                CpfOrCnpj = medicoViewModel.CpfOrCnpj,
                Email = medicoViewModel.Email,
                EstadoCivil = medicoViewModel.EstadoCivil,
                Rg = medicoViewModel.Rg,
                DataEmissaoRg = medicoViewModel.DataEmissaoRg,
                DataNascimentoOuFundacao = medicoViewModel.DataNascimentoOuFundacao,
                OrgaoEmissorRg = medicoViewModel.OrgaoEmissorRg,
                Sexo = medicoViewModel.Sexo
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="medicoViewModel"></param>
        public static explicit operator Medico(MedicoViewModel medicoViewModel)
        {
            return new Medico
            {
                MedicoId = medicoViewModel.MedicoId,
                Crm = medicoViewModel.Crm,
                EspecialidadeId = medicoViewModel.EspecialidadeId
            };
        }


    }
}
