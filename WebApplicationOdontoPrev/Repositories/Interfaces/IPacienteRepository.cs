﻿using WebApplicationOdontoPrev.Dtos;
using WebApplicationOdontoPrev.Models;

namespace WebApplicationOdontoPrev.Repositories.Interfaces
{
    public interface IPacienteRepository
    {
        Task<Paciente> Create(PacienteDtos paciente);
        Task<Paciente> Update(string nrCpf, PacienteDtos paciente);
        Task<Models.Paciente> UpdateById(int id, PacienteDtos paciente);
        public void Delete(string nrCpf);
        Task<List<Paciente>> GetAll();
        Task<Paciente> GetByNrCpf(string nrCpf);
        Task<Paciente> GetById(int id);
        Task<bool> DeleteById(int id);
    }
}
