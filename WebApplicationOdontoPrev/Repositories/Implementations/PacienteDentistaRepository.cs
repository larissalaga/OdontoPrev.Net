using Microsoft.EntityFrameworkCore;
using WebApplicationOdontoPrev.Data;
using WebApplicationOdontoPrev.Dtos;
using WebApplicationOdontoPrev.Models;
using WebApplicationOdontoPrev.Repositories.Interfaces;

namespace WebApplicationOdontoPrev.Repositories.Implementations
{
    public class PacienteDentistaRepository : IPacienteDentistaRepository
    {
        private DataContext _context;
        public PacienteDentistaRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<PacienteDentista> Create(PacienteDentistaDtos pacienteDentista)
        {
            var newPacienteDentista = new PacienteDentista
            {
                IdPaciente = pacienteDentista.IdPaciente,
                IdDentista = pacienteDentista.IdDentista
            };
            _context.PacienteDentista.Add(newPacienteDentista);
            await _context.SaveChangesAsync();
            return newPacienteDentista;
        }
        public async void Delete(int id_paciente, int id_dentista)
        {
            var getPacienteDentista = await _context.PacienteDentista.FirstOrDefaultAsync(x => x.IdPaciente == id_paciente && x.IdDentista == id_dentista);
            if (getPacienteDentista == null)
            {
                throw new Exception("PacienteDentista não encontrado.");
            }
            else
            {
                _context.PacienteDentista.Remove(getPacienteDentista);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> DeleteByIdPaciente(int id_paciente)
        {
            var getPacienteDentista = await _context.PacienteDentista.FirstOrDefaultAsync(x => x.IdPaciente == id_paciente);
            if (getPacienteDentista == null)
            {
                return true;
            }
            else
            {
                _context.PacienteDentista.Remove(getPacienteDentista);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<List<PacienteDentista>> GetAll()
        {
            var getPacienteDentista = await _context.PacienteDentista.ToListAsync();
            if (getPacienteDentista != null)
            {
                return getPacienteDentista;
            }
            else
            {
                throw new Exception("PacienteDentista não encontrado.");
            }
        }

        public async Task<List<PacienteDentista>> GetByPaciente(int id_paciente)
        {
            var getPacienteDentista = await _context.PacienteDentista.Where(x => x.IdPaciente == id_paciente).ToListAsync();
            if (getPacienteDentista != null)
            {
                return getPacienteDentista;
            }
            else
            {
                throw new Exception("PacienteDentista não encontrado.");
            }
        }

        public async Task<PacienteDentista> GetById(int id_paciente, int id_dentista)
        {
            var getPacienteDentista = await _context.PacienteDentista.FirstOrDefaultAsync(x => x.IdPaciente == id_paciente && x.IdDentista == id_dentista);
            if (getPacienteDentista != null)
            {
                return getPacienteDentista;
            }
            else
            {
                throw new Exception("PacienteDentista não encontrado.");
            }
        }

    }
}
