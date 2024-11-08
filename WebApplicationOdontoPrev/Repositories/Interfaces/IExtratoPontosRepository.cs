using WebApplicationOdontoPrev.Dtos;
using WebApplicationOdontoPrev.Models;

namespace WebApplicationOdontoPrev.Repositories.Interfaces
{
    public interface IExtratoPontosRepository
    {
        Task<ExtratoPontos> Create(ExtratoPontosDtos extratoPontos);
        Task<ExtratoPontos> Update(int IdExtratoPontos, ExtratoPontosDtos extratoPontos);
        public void Delete(int IdExtratoPontos);
        Task<List<ExtratoPontos>> GetAll();
        Task<List<ExtratoPontos>> GetById(int idPaciente);
        Task<int> GetTotalPontosByPacienteId(int idPaciente);
    }
}
