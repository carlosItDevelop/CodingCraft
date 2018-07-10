using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class BalancoHidrico
    {
        // Chaves

        [Key]
        public int BalancoHidricoId { get; set; }

        [ForeignKey("Paciente")]
        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public Guid PacienteId { get; set; }

        [ForeignKey("Prontuario")]
        [Display(Name = "Prontuário")]
        [Required(ErrorMessage = "Prontuário é campo obrigatório!")]
        public Guid ProntuarioGuid { get; set; }


        // Properties

        [Required(ErrorMessage = "Campo obrigatório!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data")]
        public DateTime DataBalancoHidrico { get; set; }


        [Display(Name = "Picos Febris")]
        public decimal PicosFebris { get; set; }

        public decimal Diurese { get; set; }

        public decimal Febre { get; set; }

        [Display(Name = "Diálise")]
        public decimal Dialise { get; set; }

        [Display(Name = "BH Parcial")]
        public decimal BhParcial { get; set; }

        [Display(Name = "BH Cumulativo")]
        public decimal BhCumulativo { get; set; }

        public decimal Creatinina { get; set; }

        public virtual Paciente Paciente { get; private set; }

        public virtual Prontuario Prontuario { get; private set; }
    }
}
