using System;

namespace Cooperchip.MedicalManagement.Domain.Entidade.Interfaces
{
    public interface IEntidadeNaoEditavel
    {
        DateTime DataInclusao { get; set; }
        string UsuarioInclusao { get; set; }
    }
}
