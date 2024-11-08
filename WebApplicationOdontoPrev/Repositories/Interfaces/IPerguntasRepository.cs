using WebApplicationOdontoPrev.Dtos;
using WebApplicationOdontoPrev.Models;

namespace WebApplicationOdontoPrev.Repositories.Interfaces
{
    public interface IPerguntasRepository
    {
        Task<Perguntas> Create(PerguntasDtos perguntas);
        public void Delete(int IdPergunta);
        Task<List<Perguntas>> GetAll();
        Task<Perguntas> GetById(int IdPergunta);
        Task<Perguntas> GetPerguntaAleatoriaAsync();
    }
}
