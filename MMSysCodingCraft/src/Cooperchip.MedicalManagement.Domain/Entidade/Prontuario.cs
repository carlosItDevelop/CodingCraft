using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class Prontuario
    {
        public Prontuario()
        {
            ProntuarioId = Guid.NewGuid();
            DataProntuario = DateTime.Now;
        }

        [Key]
        public Guid ProntuarioId { get; set; }

        [Display(Name = "Data do Prontuário")]
        [DataType(DataType.Date, ErrorMessage = "Data Inválida.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataProntuario { get; set; }

        [Display(Name = "Nº Atendimento")]
        [Required(ErrorMessage = "Campo requerido.")]
        [MaxLength(10, ErrorMessage = "Máximo de Caracter: 10.")]
        [MinLength(6, ErrorMessage = "Mínimo de Caracter: 6.")]
        public string NumAtendimento { get; set; }


        [Display(Name = "PAM")]
        [MaxLength(50, ErrorMessage = "Máximo de Caracter Permitidos: 50")]
        public string Pam { get; set; }


        [DataType(DataType.Date, ErrorMessage = "Data Inválida.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PamData { get; set; }

        [Display(Name = "Hemodiálise")]
        [MaxLength(50, ErrorMessage = "Máximo de Caracter Permitidos: 50")]
        public string Hemodialise { get; set; }


        [Display(Name = "Data")]
        [DataType(DataType.Date, ErrorMessage = "Data Inválida.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> HemodialiseData { get; set; }


        [Display(Name = "Via Aérea")]
        [MaxLength(50, ErrorMessage = "Máximo de Caracter Permitidos: 50")]
        public string ViaAerea { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data Inválida.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> ViaAereaData { get; set; }


        [Display(Name = "Via Digestiva")]
        [MaxLength(50, ErrorMessage = "Máximo de Caracter Permitidos: 50")]
        public string ViaDigestiva { get; set; }

        [Display(Name = "Data")]
        [DataType(DataType.Date, ErrorMessage = "Data Inválida.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> ViaDigestivaData { get; set; }


        [Display(Name = "Acesso Venoso")]
        [MaxLength(50, ErrorMessage = "Máximo de Caracter Permitidos: 50")]
        public string AcessoVenoso { get; set; }


        [Display(Name = "Data")]
        [DataType(DataType.Date, ErrorMessage = "Data Inválida.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> AcessoVenosoData { get; set; }


        [Display(Name = "Marcapasso")]
        [MaxLength(50, ErrorMessage = "Máximo de Caracter Permitidos: 50")]
        public string Marcapasso { get; set; }


        [Display(Name = "Data")]
        [DataType(DataType.Date, ErrorMessage = "Data Inválida.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> MarcapassoData { get; set; }


        [Display(Name = "Via Urinária")]
        [MaxLength(50, ErrorMessage = "Máximo de Caractere Permitidos: 50")]
        public string ViaUrinaria { get; set; }


        [Display(Name = "Data")]
        [DataType(DataType.Date, ErrorMessage = "Data Inválida.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> ViaUrinariaData { get; set; }


        [Display(Name = "PIC")]
        [MaxLength(50, ErrorMessage = "Máximo de Caracter Permitidos: 50")]
        public string Pic { get; set; }


        [Display(Name = "PIA")]
        [MaxLength(50, ErrorMessage = "Máximo de Caracter Permitidos: 50")]
        public string Pia { get; set; }


        [Display(Name = "Data")]
        [DataType(DataType.Date, ErrorMessage = "Data Inválida")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> PicData { get; set; }

        [Display(Name = "Data")]
        [DataType(DataType.Date, ErrorMessage = "Data Inválida")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> PiaData { get; set; }



        [Display(Name = "Anti-Coagulação")]
        [MaxLength(25, ErrorMessage = "Máximo de Caracter permitido: 25")]
        public string Anticoagulacao { get; set; }


        /* Carlos Refatorando com Guids */

        [ForeignKey("Paciente")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Paciente")]
        public Guid PacienteId { get; set; }


        public virtual Paciente Paciente { get; set; }


    }
}
