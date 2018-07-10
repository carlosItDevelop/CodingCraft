using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class Endereco
    {
        [Key]
        public int EnderecoId { get; set; }

        [ForeignKey("Paciente")]
        [Required(ErrorMessage = "Campo requerido.")]
        public Guid PacienteId { get; set; }

        [ForeignKey("Uf")]
        [Required]
        public int IdUf { get; set; }

        [ForeignKey("Cidade")]
        [Required]
        public int IdCidade { get; set; }

        [ForeignKey("Bairro")]
        [Required]
        public int IdBairro { get; set; }

        [Required]
        public string Local { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Referencia { get; set; }

        [Required]
        [MaxLength(9)]
        public string Cep { get; set; }

        public virtual Uf Uf { get; set; }
        public virtual Cidade Cidade { get; set; }
        public virtual Bairro Bairro { get; set; }
        public virtual Paciente Paciente { get; set; }

    }
}
