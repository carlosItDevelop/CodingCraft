using System.ComponentModel.DataAnnotations;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class Contato
    {

        [Key]
        public int ContatoId { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Data { get; set; }

        public string Operadora { get; set; }

    }
}


