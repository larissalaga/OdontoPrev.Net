using WebApplicationOdontoPrev.Dtos;
using WebApplicationOdontoPrev.Models;

namespace WebApplicationOdontoPrev.Repositories.Interfaces
{
    public interface IRespostasRepository
    {
        Task<Respostas> Create(RespostasDtos respostas);
        Task<Respostas> Update(int id, RespostasDtos respostas);
        Task<bool> Delete(int id);
        Task<List<Respostas>> GetAll();
        Task<Respostas> GetById(int id);

    }
}
