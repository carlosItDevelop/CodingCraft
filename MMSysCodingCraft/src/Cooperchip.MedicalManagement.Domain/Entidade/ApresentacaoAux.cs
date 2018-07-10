using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class ApresentacaoAux
    {
        [Key]
        public int ApresentacaoId { get; set; }
        public string Apresentacao1 { get; set; }
        public string Apresentacao2 { get; set; }
        public string Apresentacao3 { get; set; }
        public string Apresentacao4 { get; set; }
        public string Apresentacao5 { get; set; }
        public string Apresentacao6 { get; set; }
        public string Apresentacao7 { get; set; }
        public string Apresentacao8 { get; set; }
        public string Apresentacao9 { get; set; }
        public string Apresentacao10 { get; set; }
        public string Apresentacao11 { get; set; }
    }
}
