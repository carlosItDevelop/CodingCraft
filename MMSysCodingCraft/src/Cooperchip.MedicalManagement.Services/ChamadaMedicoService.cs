using Cooperchip.MedicalManagement.Infra.Data;
using System.Linq;
using PagedList;
using Cooperchip.MedicalManagement.Domain.Entidade;

namespace Cooperchip.MedicalManagement.Services
{
    public class ChamadaMedicoService
    {
        private MedicalManagementDbContext _db = new MedicalManagementDbContext();
        private int qtdePorPage = 6;
        public IPagedList<ChamadaMedico> GetChamadaMedico(int? pagechamada)
        {
            int numeroOfPageChamada = (pagechamada ?? 1);
            var listaPacientes = _db.ChamadaMedico.ToList();

            return listaPacientes.ToPagedList(numeroOfPageChamada, qtdePorPage);
        }

    }
}

