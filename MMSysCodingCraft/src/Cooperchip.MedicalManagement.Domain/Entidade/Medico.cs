using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    [Table("Medicos")]
    public class Medico
    {
        [Key, ForeignKey(nameof(PessoaFisica))]
        public Guid MedicoId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(80, ErrorMessage = "Máximo de caractere permitido: 80")]
        public string Nome { get; set; }

        [Display(Name = "CRM")]
        [StringLength(10, ErrorMessage = "Máximo de caracteres permitidos: 10")]
        public string Crm { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Especialidade")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public int EspecialidadeId { get; set; }

        public virtual Especialidade Especialidade { get; set; }
        public virtual PessoaFisica PessoaFisica { get; set; }
    }
}
