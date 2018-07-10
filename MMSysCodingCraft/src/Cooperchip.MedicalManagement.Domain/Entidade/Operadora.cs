using System.ComponentModel.DataAnnotations;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class Operadora
    {
        [Key]
        public int OperadoraId { get; set; }

        public string Nome { get; set; }

        public string Codigo { get; set; }

        public string Categoria { get; set; }

        public string Preco { get; set; }


    }
}
