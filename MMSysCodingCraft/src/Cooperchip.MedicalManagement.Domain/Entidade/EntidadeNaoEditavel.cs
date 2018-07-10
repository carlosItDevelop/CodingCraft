using Cooperchip.MedicalManagement.Domain.Entidade.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public abstract class EntidadeNaoEditavel : IEntidadeNaoEditavel
    {
        [Display(Name = "Data da Inclusão")]
        public DateTime DataInclusao { get; set; }
        [Display(Name = "Usuário da Inclusão")]
        public string UsuarioInclusao { get; set; }
    }
}
