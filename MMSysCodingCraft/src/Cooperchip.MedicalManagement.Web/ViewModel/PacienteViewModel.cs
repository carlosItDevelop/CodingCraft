using Cooperchip.MedicalManagement.Domain.Entidade;
using Cooperchip.MedicalManagement.Domain.Validations;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cooperchip.MedicalManagement.Web.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    [Validator(typeof(PacienteValidator))]
    public class PacienteViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public PacienteViewModel()
        {
            this.PacienteId = Guid.NewGuid();
            this.DataInternacao = DateTime.Now;
            this.Ativo = true;
        }


        [Key]
        [Required(ErrorMessage = "Campo requerido.")]
        public Guid PacienteId { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public int Peso { get; set; }

        //Idade, calculado pela data de nascimento;


        [Display(Name = "Internação")]
        [Required(ErrorMessage = "Campo requerido.")]
        [DataType(DataType.Date, ErrorMessage = "Data Inválida.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataInternacao { get; set; }

        [Display(Name = "CPF")]
        [MaxLength(14, ErrorMessage = "Máximo de Caractere mermitido: 14")]
        public string Cpf { get; set; }

        [MaxLength(14, ErrorMessage = "Máximo de Caractere mermitido: 14")]
        [Display(Name = "RG")]
        public string Rg { get; set; }

        [Display(Name = "O Emissor")]
        [MaxLength(10, ErrorMessage = "Máximo de Caractere mermitido: 10")]
        public string RgOrgao { get; set; }

        [Display(Name = "Dt Emissão")]
        [DataType(DataType.Date, ErrorMessage = "Data Inválida.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RgDataEmissao { get; set; }

        [MaxLength(200, ErrorMessage = "Máximo de Caractere mermitido: 200")]
        public string Email { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo Obrigatório.")]
        [MaxLength(70, ErrorMessage = "Máximo de 70 caractere(s) permitido(s).")]
        public string Nome { get; set; }

        public bool Ativo { get; set; }

        [Display(Name = "Nascimento")]
        [DataType(DataType.Date, ErrorMessage = "Data Inválida.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }



        /* ----/ Diagnósticos  ----- */

        [Display(Name = "Complicações")]
        [MaxLength(4000, ErrorMessage = "Máximo de Caractere Permitidos: 4000")]
        public string Complicacao { get; set; }

        [Display(Name = "Hist. Patol. Pregressa")]
        [MaxLength(4000, ErrorMessage = "Máximo de Caractere Permitidos: 4000")]
        public string HistoriaPatologicaPregressa { get; set; }


        [Display(Name = "Alergia")]
        [MaxLength(4000, ErrorMessage = "Máximo de Caractere Permitidos: 4000")]
        public string Alergia { get; set; }

        [Display(Name = "Cid Adaptada")]
        [MaxLength(5, ErrorMessage = "Máximo de caracteres permitidos: 5.")]
        public string CodigoCid { get; set; }


        public bool Hepatopatia { get; set; }

        public bool Gravidez { get; set; }

        [Display(Name = "Amamentação")]
        public bool Amamentacao { get; set; }


        /* ----/ Diagnósticos  ----- */


        [ForeignKey("Convenio")]
        [Display(Name = "Convénio")]
        [Required(ErrorMessage = "Campo requerido.")]
        public int idConvenio { get; set; }


        [ForeignKey("Leito")]
        [Display(Name = "Leito")]
        [Required(ErrorMessage = "Campo requerido.")]
        public int IdLeito { get; set; }


        [ForeignKey("Sexo")]
        [Required(ErrorMessage = "Sexo é obrigatório.")]
        [Display(Name = "Sexo")]
        public int idSexo { get; set; }


        [ForeignKey("EstadoDoPaciente")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Estado do Paciente")]
        public int EstadoPacienteId { get; set; }


        [ForeignKey("Setor")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Setor")]
        public int IdSetor { get; set; }


        public virtual EstadoDoPaciente EstadoDoPaciente { get; set; }
        public virtual Convenio Convenio { get; set; }
        public virtual Leito Leito { get; set; }
        public virtual Setor Setor { get; set; }

        //public ICollection<Prescricao> Prescricao { get; set; }
        //public ICollection<Prontuario> Prontuario { get; set; }
        //public ICollection<BalancoHidrico> BalancoHidrico { get; set; }
        //public ICollection<AtbEmUso> AtbEmUso { get; set; }
        //public ICollection<AtbJaUtilizado> AtbJaUtilizado { get; set; }
        //public ICollection<ExameDeImagem> ExameDeImagem { get; set; }
        //public ICollection<ProntuarioPrecaucao> ProntuarioPrecaucao { get; set; }
        //public ICollection<ResultadoExame> ResultadoExame { get; set; }
        //public ICollection<TelefonePaciente> TelefonePaciente { get; set; }
        //public ICollection<SinaisVitais> SinaisVitais { get; set; }
        //public ICollection<Dreno> Dreno { get; set; }
    }
}