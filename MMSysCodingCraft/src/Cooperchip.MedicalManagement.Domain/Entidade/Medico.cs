using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    [Table("Medicos")]
    public class Medico : Entidade
    {
        [Key, ForeignKey(nameof(PessoaFisica))]
        public Guid MedicoId { get; set; }


        [Display(Name = "CRM")]
        [StringLength(10, ErrorMessage = "Máximo de caracteres permitidos: 10")]
        public string Crm { get; set; }



        [Display(Name = "Especialidade")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public int EspecialidadeId { get; set; }

        public virtual Especialidade Especialidade { get; set; }

        [ForeignKey(nameof(MedicoId))]
        public virtual PessoaFisica PessoaFisica { get; set; }
    }
}
