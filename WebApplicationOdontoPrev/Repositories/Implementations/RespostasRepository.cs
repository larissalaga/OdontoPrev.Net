using Microsoft.EntityFrameworkCore;
using WebApplicationOdontoPrev.Data;
using WebApplicationOdontoPrev.Dtos;
using WebApplicationOdontoPrev.Models;
using WebApplicationOdontoPrev.Repositories.Interfaces;

namespace WebApplicationOdontoPrev.Repositories.Implementations
{
    public class RespostasRepository : IRespostasRepository
    {
        private DataContext _context;
        public RespostasRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Models.Respostas> Create(RespostasDtos respostas)
        {
            var newRespostas = new Models.Respostas
            {
                DsResposta = respostas.DsResposta
            };
            _context.Respostas.Add(newRespostas);
            await _context.SaveChangesAsync();
            return newRespostas;
        }

        public async Task<bool> Delete(int id)
        {
            var getRespostas = await _context.Respostas.FirstOrDefaultAsync(x => x.IdResposta == id);
            if (getRespostas == null)
            {
                return true;
            }
            else
            {
                _context.Respostas.Remove(getRespostas);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<Models.Respostas>> GetAll()
        {
            var getRespostas = await _context.Respostas.ToListAsync();
            if (getRespostas != null)
            {
                return getRespostas;
            }
            else
            {
                throw new Exception("Nenhuma resposta encontrada.");
            }
        }

        public async Task<Models.Respostas> GetById(int id)
        {
            var getRespostas = await _context.Respostas.FirstOrDefaultAsync(x => x.IdResposta == id);
            if (getRespostas == null)
            {
                throw new Exception("Respostas não encontrada.");
            }
            else
            {
                return getRespostas;
            }
        }

        public async Task<Models.Respostas> Update(int id, RespostasDtos respostas)
        {
            var getRespostas = await _context.Respostas.FirstOrDefaultAsync(x => x.IdResposta == id);
            if (getRespostas == null)
            {
                throw new Exception("Respostas não encontrada.");
            }
            else
            {
                getRespostas.DsResposta = respostas.DsResposta;
                await _context.SaveChangesAsync();
                return getRespostas;
            }
        }
    }
}
