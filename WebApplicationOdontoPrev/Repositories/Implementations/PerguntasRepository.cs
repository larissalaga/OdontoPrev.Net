using Microsoft.EntityFrameworkCore;
using WebApplicationOdontoPrev.Data;
using WebApplicationOdontoPrev.Dtos;
using WebApplicationOdontoPrev.Models;
using WebApplicationOdontoPrev.Repositories.Interfaces;


namespace WebApplicationOdontoPrev.Repositories.Implementations
{
    public class PerguntasRepository : IPerguntasRepository
    {
        private DataContext _context;
        public PerguntasRepository(DataContext context) 
        {
            _context = context;
        }
        public async Task<Models.Perguntas> Create(PerguntasDtos perguntas)
        {
            var newPerguntas = new Models.Perguntas
            {
                DsPergunta = perguntas.DsPergunta
            };
            _context.Perguntas.Add(newPerguntas);
            await _context.SaveChangesAsync();
            return newPerguntas;
        }

        public async void Delete(int idPergunta)
        {
            var getPerguntas = await _context.Perguntas.FirstOrDefaultAsync(x => x.IdPergunta == idPergunta);
            if (getPerguntas == null)
            {
                throw new Exception("Pergunta não encontrada.");
            }
            else
            {
                _context.Perguntas.Remove(getPerguntas);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Models.Perguntas>> GetAll()
        {
            var getPerguntas = await _context.Perguntas.ToListAsync();
            if (getPerguntas != null)
            {
                return getPerguntas;
            }
            else
            {
                throw new Exception("Nenhuma pergunta encontrada.");
            }
        }

        public async Task<Models.Perguntas> GetById(int idPergunta)
        {
            var getPerguntas = await _context.Perguntas.FirstOrDefaultAsync(x => x.IdPergunta == idPergunta);
            if (getPerguntas == null)
            {
                throw new Exception("Pergunta não encontrada.");
            }
            else
            {
                return getPerguntas;
            }
        }

        public async Task<Models.Perguntas> GetPerguntaAleatoriaAsync()
        {
            if (!_context.Perguntas.Any())
            {
                throw new Exception("Nenhuma pergunta encontrada.");
            }

            return await _context.Perguntas.OrderBy(x => Guid.NewGuid()).FirstOrDefaultAsync();
        }
    }
}
