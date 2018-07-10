using Cooperchip.MedicalManagement.Domain.Entidade.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public abstract class Entidade : EntidadeNaoEditavel, IEntidade
    {
        [Display(Name = "Data da Última Modificação")]
        public DateTime? DataUltimaModificacao { get; set; }
        [Display(Name = "Usuário da Última Modificação")]
        public string UsuarioUltimaModificacao { get; set; }
    }
}
