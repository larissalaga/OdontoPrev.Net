using Microsoft.EntityFrameworkCore;
using WebApplicationOdontoPrev.Data;
using WebApplicationOdontoPrev.Dtos;
using WebApplicationOdontoPrev.Models;
using WebApplicationOdontoPrev.Repositories.Interfaces;

namespace WebApplicationOdontoPrev.Repositories.Implementations
{
    public class PacienteRepository : IPacienteRepository
    {
        private DataContext _context;

        public PacienteRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Models.Paciente> Create(PacienteDtos paciente)
        {
            var getPaciente = await _context.Paciente.FirstOrDefaultAsync(x => x.NrCpf == paciente.NrCpf);
             if (getPaciente != null)
            {
                throw new Exception("Paciente já cadastrado.");
            }
            else
            {
                var newPaciente = new Models.Paciente
                {
                    NmPaciente = paciente.NmPaciente,
                    NrCpf = paciente.NrCpf,
                    NrTelefone = paciente.NrTelefone,
                    DsEmail = paciente.DsEmail,
                    DtNascimento = paciente.DtNascimento,
                    DsSexo = paciente.DsSexo,
                    IdPlano = paciente.IdPlano
                };
                _context.Paciente.Add(newPaciente);
                await _context.SaveChangesAsync();
                return newPaciente;
            }
        }

        public async void Delete(string nr_cpf)
        {
            var getPaciente = await _context.Paciente.FirstOrDefaultAsync(x => x.NrCpf == nr_cpf);
            if (getPaciente == null)
            {
                throw new Exception("Paciente não encontrado.");
            }
            else
            {
                _context.Paciente.Remove(getPaciente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Models.Paciente>> GetAll()
        {
            var getPaciente = await _context.Paciente.ToListAsync();
            if (getPaciente != null)
            {
                return getPaciente;
            }
            else
            {
                throw new Exception("Não há pacientes cadastrados.");
            }
        }

        public async Task<Models.Paciente> GetByNrCpf(string nrCpf)
        {
            var getPaciente = await _context.Paciente.FirstOrDefaultAsync(x => x.NrCpf == nrCpf);
            if (getPaciente == null)
                throw new Exception("Paciente não encontrado.");
            else
                return getPaciente;
        }

        public async Task<Models.Paciente> GetById(int id)
        {
            var getPaciente = await _context.Paciente.FirstOrDefaultAsync(x => x.IdPaciente == id);
            if (getPaciente == null)
                throw new Exception("Paciente não encontrado.");
            else
                return getPaciente;
        }

        public async Task<Models.Paciente> UpdateById(int id, PacienteDtos paciente)
        {
            var getPaciente = await _context.Paciente.FirstOrDefaultAsync(x => x.IdPaciente == id);
            if (getPaciente == null)
            {
                throw new Exception("Paciente não encontrado.");
            }
            else
            {
                getPaciente.NmPaciente = paciente.NmPaciente;
                getPaciente.NrCpf = paciente.NrCpf;
                getPaciente.NrTelefone = paciente.NrTelefone;
                getPaciente.DsEmail = paciente.DsEmail;
                getPaciente.DtNascimento = paciente.DtNascimento;
                getPaciente.DsSexo = paciente.DsSexo;
                getPaciente.IdPlano = paciente.IdPlano;
                await _context.SaveChangesAsync();
                return getPaciente;
            }
        }

            public async Task<Models.Paciente> Update(string nrCpf , PacienteDtos paciente)
        {
            var getPaciente = await _context.Paciente.FirstOrDefaultAsync(x => x.NrCpf == paciente.NrCpf);
            if (getPaciente == null)
            {
                throw new Exception("Paciente não encontrado.");
            }
            else
            {
                getPaciente.NmPaciente = paciente.NmPaciente;
                getPaciente.NrCpf = paciente.NrCpf;
                getPaciente.NrTelefone = paciente.NrTelefone;
                getPaciente.DsEmail = paciente.DsEmail;
                getPaciente.DtNascimento = paciente.DtNascimento;
                getPaciente.DsSexo = paciente.DsSexo;
                getPaciente.IdPlano = paciente.IdPlano;
                await _context.SaveChangesAsync();
                return getPaciente;
            }
        }
    }
}
