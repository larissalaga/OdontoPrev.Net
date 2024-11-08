using Microsoft.EntityFrameworkCore;
using WebApplicationOdontoPrev.Data;
using WebApplicationOdontoPrev.Dtos;
using WebApplicationOdontoPrev.Models;
using WebApplicationOdontoPrev.Repositories.Interfaces;

namespace WebApplicationOdontoPrev.Repositories.Implementations
{
    public class ExtratoPontosRepository : IExtratoPontosRepository
    {
        private DataContext _context;
        public ExtratoPontosRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Models.ExtratoPontos> Create(ExtratoPontosDtos extratoPontos)
        {   
                var newExtratoPontos = new Models.ExtratoPontos
                {
                    DtExtrato = extratoPontos.DtExtrato,
                    NrNumeroPontos = extratoPontos.NrNumeroPontos,
                    DsMovimentacao = extratoPontos.DsMovimentacao,
                    IdPaciente = extratoPontos.IdPaciente
                };
                _context.ExtratoPontos.Add(newExtratoPontos);
                await _context.SaveChangesAsync();
                return newExtratoPontos;            
        }

        public async void Delete(int IdExtratoPontos)
        {
            var getExtratoPontos = await _context.ExtratoPontos.FirstOrDefaultAsync(x => x.IdExtratoPontos == IdExtratoPontos);
            if (getExtratoPontos == null)
            {
                throw new Exception("Extrato de pontos não encontrado.");
            }
            else
            {
                _context.ExtratoPontos.Remove(getExtratoPontos);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Models.ExtratoPontos>> GetAll()
        {
            var getExtratoPontos = await _context.ExtratoPontos.ToListAsync();
            if (getExtratoPontos != null)
            {
                return getExtratoPontos;
            }
            else
            {
                throw new Exception("Nenhum extrato de pontos encontrado.");
            }
        }

        public async Task<List<Models.ExtratoPontos>> GetById(int idPaciente)
        {
            var getExtratoPontos = await _context.ExtratoPontos.ToListAsync();
            if (getExtratoPontos == null)
            {
                throw new Exception("Extratos de pontos não encontrados.");
            }
            else
            {
                return getExtratoPontos;
            }
        }
        public async Task<int> GetTotalPontosByPacienteId(int idPaciente)
        {
            var totalPontos = await _context.ExtratoPontos
                .Where(x => x.IdPaciente == idPaciente)
                .SumAsync(x => (int?)x.NrNumeroPontos) ?? 0;

            return totalPontos;
        }
        public async Task<Models.ExtratoPontos> Update(int IdExtratoPontos, ExtratoPontosDtos extratoPontos)
        {
            var getExtratoPontos = await _context.ExtratoPontos.FirstOrDefaultAsync(x => x.IdExtratoPontos == IdExtratoPontos);
            if (getExtratoPontos == null)
            {
                throw new Exception("Extrato de pontos não encontrado.");
            }
            else
            {
                getExtratoPontos.DtExtrato = extratoPontos.DtExtrato;
                getExtratoPontos.NrNumeroPontos = extratoPontos.NrNumeroPontos;
                getExtratoPontos.DsMovimentacao = extratoPontos.DsMovimentacao;
                getExtratoPontos.IdPaciente = extratoPontos.IdPaciente;
                await _context.SaveChangesAsync();
                return getExtratoPontos;
            }
        }
    }
}
