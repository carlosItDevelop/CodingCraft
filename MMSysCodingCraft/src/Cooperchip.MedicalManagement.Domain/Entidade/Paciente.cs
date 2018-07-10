using Cooperchip.MedicalManagement.Domain.Enum;
using Cooperchip.MedicalManagement.Domain.Validations;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    [Validator(typeof(PacienteValidator))]
    public class Paciente
    {
        public Paciente()
        {
            this.PacienteId = Guid.NewGuid();
            this.DataInternacao = DateTime.Now;
        }

        [Key, ForeignKey(nameof(PessoaFisica))]
        public Guid PacienteId { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public int Peso { get; set; }

        //Idade, calculado pela data de nascimento;


        [Display(Name = "Internação")]
        [Required(ErrorMessage = "Campo requerido.")]
        [DataType(DataType.Date, ErrorMessage = "Data Inválida.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataInternacao { get; set; }

        /* ----/ Diagnósticos  ----- */

        [Display(Name = "Complicações")]
        [MaxLength(4000, ErrorMessage = "Máximo de Caractere Permitidos: 4000")]
        public string Complicacao { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Hist. Patol. Pregressa")]
        [MaxLength(4000, ErrorMessage = "Máximo de Caractere Permitidos: 4000")]
        public string HistoriaPatologicaPregressa { get; set; }

        [DataType(DataType.MultilineText)]
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
        public int ConvenioId { get; set; }


        [ForeignKey("Leito")]
        [Display(Name = "Leito")]
        [Required(ErrorMessage = "Campo requerido.")]
        public int LeitoId { get; set; }


        [Required(ErrorMessage = "Sexo é obrigatório.")]
        [Display(Name = "Sexo")]
        public Sexo Sexo { get; set; }

        [ForeignKey("EstadoDoPaciente")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Estado do Paciente")]
        public int EstadoPacienteId { get; set; }


        [ForeignKey("Setor")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Setor")]
        public int SetorId { get; set; }

        public virtual PessoaFisica PessoaFisica { get; set; }

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

        public virtual ICollection<ResultadoExame> ResultadoExame { get; set; }
        //public ICollection<TelefonePaciente> TelefonePaciente { get; set; }
        //public ICollection<SinaisVitais> SinaisVitais { get; set; }
        //public ICollection<Dreno> Dreno { get; set; }

    }
}
