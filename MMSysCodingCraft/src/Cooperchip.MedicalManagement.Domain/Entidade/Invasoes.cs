using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class Invasoes
    {

        public Invasoes()
        {
            this.InvasoesId = Guid.NewGuid();
        }

        [Key]
        public Guid InvasoesId { get; set; }

        /* Carlos Refatorando com Guids */
        [ForeignKey("ProntuarioBase")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Prontuário")]
        public Guid ProntuarioGuid { get; set; }

        [ForeignKey("Paciente")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Paciente")]
        public Guid PacienteId { get; set; }
        /* Carlos Refatorando com Guids */

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

        /* ---/ Objets virtuais de navegação ----- */

        public virtual Paciente Paciente { get; set; }
        public virtual ProntuarioBase ProntuarioBase { get; set; }

    }
}
