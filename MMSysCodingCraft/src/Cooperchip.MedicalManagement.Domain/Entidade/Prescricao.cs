using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class Prescricao
    {
        public Prescricao()
        {
            this.PrescricaoId = Guid.NewGuid();
            this.DataPrescricao = DateTime.Now;
        }

        [Key]
        public Guid PrescricaoId { get; set; }

        [ForeignKey("Paciente")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Paciente")]
        public Guid PacienteId { get; set; }

        [ForeignKey("Prontuario")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Prontuário")]
        public Guid ProntuarioGuid { get; set; }

        [Display(Name = "Data da Prescrição")]
        [DataType(DataType.Date, ErrorMessage = "Data Inválida.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataPrescricao { get; set; }

        [MaxLength(12,ErrorMessage = "Máximo de caracter permitido: 12.")]
        public string Dieta { get; set; }

        [MaxLength(25, ErrorMessage = "Máximo de caracter permitido: 25.")]
        public string DietaSondaGastrica { get; set; }

        public string DietaConsistencia { get; set; }

        public string DietaComorbidade { get; set; }

        public string DietaVolume { get; set; }

        public string Hidratacao { get; set; }

        public string HidratacaoVolume { get; set; }

        public string NebulizacaoIntervalo { get; set; }

        [MaxLength(20,ErrorMessage = "Máximo de caracter: 20.")]
        public string Berotec { get; set; }
        public int BerotecGotas { get; set; }

        [MaxLength(20, ErrorMessage = "Máximo de caracter: 20.")]
        public string Atrovent { get; set; }
        public int AtroventGotas { get; set; }

        [MaxLength(20, ErrorMessage = "Máximo de caracter: 20.")]
        public string Fluimucil { get; set; }

        public int FluimucilGotas { get; set; }

        [MaxLength(20, ErrorMessage = "Máximo de caracter: 20.")]
        public string Sf09 { get; set; }

        public int Sf09Gotas { get; set; }

        [MaxLength(20, ErrorMessage = "Máximo de caracter: 20.")]
        public string Antiacido { get; set; }

        public string AntiacidoPosologia { get; set; }

        [MaxLength(20, ErrorMessage = "Máximo de caracter: 20.")]
        public string Anticoagulacao { get; set; }

        public string AnticoagulacaoPosologia { get; set; }

        [MaxLength(20, ErrorMessage = "Máximo de caracter: 20.")]
        public string Procinetico { get; set; }

        public string ProcineticoIntervalo { get; set; }

        public bool Amiodarana { get; set; }
        public bool Dobutamina { get; set; }
        public bool Dopamina { get; set; }
        public bool Noradrenalina { get; set; }
        public bool Nitroprussiato { get; set; }
        public bool Nitroglicerina { get; set; }
        public bool Midazolam { get; set; }
        public bool Fentanil { get; set; }

        [MaxLength(25,ErrorMessage = "Máximo de 25 caracter permitidos!")]
        public string GlicemiaCapilar { get; set; }

        [MaxLength(25, ErrorMessage = "Máximo de 25 caracter permitidos!")]
        public string InsulinaRegular { get; set; }

        [MaxLength(25, ErrorMessage = "Máximo de 25 caracter permitidos!")]
        public string Oxigenoterapia { get; set; }

        [MaxLength(25, ErrorMessage = "Máximo de 25 caracter permitidos!")]
        public string Fisioterapia { get; set; }

        [MaxLength(25, ErrorMessage = "Máximo de 25 caracter permitidos!")]
        public string FebreDor { get; set; }

        [MaxLength(25, ErrorMessage = "Máximo de 25 caracter permitidos!")]
        public string Emese { get; set; }
        public bool Captopril { get; set; }

        public virtual Paciente Paciente { get; set; }
        public virtual Prontuario Prontuario { get; set; }

    }
}
