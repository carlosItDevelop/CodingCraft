using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooperchip.MedicalManagement.Domain.Entidade.Interfaces
{
    public interface IEntidade : IEntidadeNaoEditavel
    {
        DateTime? DataUltimaModificacao { get; set; }
        string UsuarioUltimaModificacao { get; set; }
    }
}
