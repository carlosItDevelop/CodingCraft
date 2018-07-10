using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class SinaisVitais
    {
        [Key]
        public int SinaisVitaisId { get; set; }

        [ForeignKey("Paciente")]
        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "Paciente é campo obrigatório!")]
        public Guid PacienteId { get; set; }


        [ForeignKey("Prontuario")]
        [Display(Name = "Prontuário")]
        [Required(ErrorMessage = "Prontuário é campo obrigatório!")]
        public Guid ProntuarioGuid { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(5, ErrorMessage = "Máximo de caracter permitido: 5.")]
        public string Hora { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(3,ErrorMessage = "Máximo de caracter permitido: 3.")]
        public string Entubado { get; set; }
        public int PressaoArterialSistolica { get; set; }
        public int PressaoArterialDiastolica { get; set; }
        public decimal FrequenciaCardiaca { get; set; }
        public decimal FrequenciaRespiratoria { get; set; }
        public decimal TemperaturaAxilar { get; set; }
        public decimal SaturacaoOxigeno { get; set; }
        public decimal Pvc { get; set; }
        public decimal Pia { get; set; }
        public decimal Pic { get; set; }
        public decimal GlicemiaCapilar { get; set; }
        public decimal Insulina { get; set; }
        public decimal Glicose { get; set; }

        public Paciente Paciente { get; private set; }
        public virtual Prontuario Prontuario { get; private set; }

    }
}
