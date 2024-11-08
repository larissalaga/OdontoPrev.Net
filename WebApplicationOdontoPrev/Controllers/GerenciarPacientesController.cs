using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using WebApplicationOdontoPrev.Dtos;
using WebApplicationOdontoPrev.Models;
using WebApplicationOdontoPrev.Repositories.Implementations;
using WebApplicationOdontoPrev.Repositories.Interfaces;
using WebApplicationOdontoPrev.ViewModels;
using static WebApplicationOdontoPrev.ViewModels.GerenciarPacientesViewModel;

namespace WebApplicationOdontoPrev.Controllers
{
    public class GerenciarPacientesController : Controller
    {
        private readonly IPacienteRepository _paciente;
        private readonly IPlanoRepository _plano;
        private readonly IDentistaRepository _dentista;
        private readonly IPacienteDentistaRepository _pacienteDentista;
        private readonly IMapper _mapper;

        public GerenciarPacientesController(
            IPacienteRepository paciente,
            IPlanoRepository plano,
            IDentistaRepository dentista,
            IPacienteDentistaRepository pacienteDentista,
            IMapper mapper
            )
        {
            _paciente = paciente;
            _plano = plano;
            _dentista = dentista;
            _pacienteDentista = pacienteDentista;
            _mapper = mapper;
        }

        private async Task<List<Dentista>> CarregarDentistas(int idPaciente)
        {
            var pacienteDentista = await _pacienteDentista.GetByPaciente(idPaciente);
            var dentistasIds = pacienteDentista.Select(x => x.IdDentista).ToList();
            return await _dentista.GetByIdList(dentistasIds);
        }

        private async Task<Plano> CarregarPlano(int idPlano)
        {
            return await _plano.GetById(idPlano);
        }

        private async Task<GerenciarPacientesViewModel> CarregarPacientes(string orderBy = "Nome", string sortOrder = "asc")
        {
            var viewModel = new GerenciarPacientesViewModel();
            var pacientes = await _paciente.GetAll();
            foreach (var paciente in pacientes)
            {
                var novoPaciente = new PacienteDados
                {
                    Paciente = paciente,
                    Dentistas = await CarregarDentistas(paciente.IdPaciente),
                    Plano = await CarregarPlano(paciente.IdPlano)
                };
                viewModel.Pacientes.Add(novoPaciente);
            }

            TempData["CurrentSortField"] = orderBy;
            TempData["CurrentSortOrder"] = sortOrder;
            TempData.Keep("CurrentSortField");
            TempData.Keep("CurrentSortOrder");

            viewModel.Pacientes = (orderBy, sortOrder) switch
            {
                ("Nome", "asc") => viewModel.Pacientes.OrderBy(p => p.Paciente.NmPaciente).ToList(),
                ("Nome", "desc") => viewModel.Pacientes.OrderByDescending(p => p.Paciente.NmPaciente).ToList(),
                ("Cpf", "asc") => viewModel.Pacientes.OrderBy(p => p.Paciente.NrCpf).ToList(),
                ("Cpf", "desc") => viewModel.Pacientes.OrderByDescending(p => p.Paciente.NrCpf).ToList(),
                ("Plano", "asc") => viewModel.Pacientes.OrderBy(p => p.Plano.NmPlano).ToList(),
                ("Plano", "desc") => viewModel.Pacientes.OrderByDescending(p => p.Plano.NmPlano).ToList(),
                ("Nascimento", "asc") => viewModel.Pacientes.OrderBy(p => p.Paciente.DtNascimento).ToList(),
                ("Nascimento", "desc") => viewModel.Pacientes.OrderByDescending(p => p.Paciente.DtNascimento).ToList(),
                _ => viewModel.Pacientes
            };

            return viewModel;
        }

        public async Task<IActionResult> OrdenarPacientes(string campo)
        {
            var currentSortOrder = TempData["CurrentSortOrder"] as string ?? "asc";
            var currentSortField = TempData["CurrentSortField"] as string ?? "Nome";
            string newSortOrder = (currentSortField == campo && currentSortOrder == "asc") ? "desc" : "asc";

            var viewModel = await CarregarPacientes(campo, newSortOrder);
            return View("Index", viewModel);
        }

        private async Task<PacienteDados> BuscarPacienteDados(int idPaciente)
        {
            var paciente = new Paciente();
            var pacienteDados = new PacienteDados();
            try
            {
                paciente = await _paciente.GetById(idPaciente);
                pacienteDados = new PacienteDados
                {
                    Paciente = paciente,
                    Dentistas = await CarregarDentistas(idPaciente),
                    Plano = await CarregarPlano(paciente.IdPlano)
                };
            }
            catch (Exception)
            {
                pacienteDados = new PacienteDados();
            }
            return pacienteDados;
        }


        public async Task<IActionResult> EditarPaciente(int id)
        {
            var pacienteDados = await BuscarPacienteDados(id);
            return View("DetalhesPaciente", pacienteDados);
        }

        private async Task<Plano> SalvarPlano(PacienteDados pacienteDados)
        {
            var plano = new Plano();

            try
            {
                // Atualiza as propriedades do Plano
                plano = await _plano.GetByDsCodigoPlano(pacienteDados.Plano.DsCodigoPlano);
                plano.DsCodigoPlano = pacienteDados.Plano.DsCodigoPlano;
                plano.NmPlano = pacienteDados.Plano.NmPlano;

                var planoDto = _mapper.Map<PlanoDtos>(plano);
                plano = await _plano.Update(plano.IdPlano, planoDto);
            }
            catch (Exception)
            {
                // Se o plano não existe, cria um novo registro
                var planoDto = _mapper.Map<PlanoDtos>(pacienteDados.Plano);
                plano = await _plano.Create(planoDto);
            }
            return plano;
        }

        private async Task<Paciente> SalvarPaciente(PacienteDados pacienteDados)
        {
            var paciente = new Paciente();
            try
            {
                // Busca o paciente existente no banco de dados
                paciente = await _paciente.GetById(pacienteDados.Paciente.IdPaciente);

                
                // Atualiza as propriedades do Paciente
                paciente.NmPaciente = pacienteDados.Paciente.NmPaciente;
                paciente.DtNascimento = pacienteDados.Paciente.DtNascimento;
                paciente.NrCpf = pacienteDados.Paciente.NrCpf;
                paciente.DsSexo = pacienteDados.Paciente.DsSexo;
                paciente.NrTelefone = pacienteDados.Paciente.NrTelefone;
                paciente.DsEmail = pacienteDados.Paciente.DsEmail;
                paciente.IdPlano = pacienteDados.Plano.IdPlano;

                // Mapeia Models para Dtos
                var pacienteDto = _mapper.Map<PacienteDtos>(paciente);

                // Salva as alterações no banco de dados
                await _paciente.Update(paciente.NrCpf, pacienteDto);                
            }
            catch (Exception ex)
            {
                // Se o paciente não existe no banco de dados, cria um novo registro
                paciente = pacienteDados.Paciente;
                paciente.IdPlano = pacienteDados.Plano.IdPlano;
                var pacienteDto = _mapper.Map<PacienteDtos>(paciente);
                await _paciente.Create(pacienteDto);
            }
            return paciente;
        }

        private async Task<Dentista> SalvarDentista(Dentista dentista)
        {
            var novoDentista = new Dentista();
            try
            {
                // Busca o dentista existente no banco de dados
                novoDentista = await _dentista.GetByDsCro(dentista.DsCro);

                // Atualiza as propriedades do Dentista
                novoDentista.NmDentista = dentista.NmDentista;
                novoDentista.DsCro = dentista.DsCro;
                novoDentista.NrTelefone = dentista.NrTelefone;
                novoDentista.DsEmail = dentista.DsEmail;

                // Mapeia Models para Dtos
                var dentistaDto = _mapper.Map<DentistaDtos>(novoDentista);

                // Salva as alterações no banco de dados
                await _dentista.Update(novoDentista.DsCro, dentistaDto);
            }
            catch (Exception)
            {
                // Se o dentista não existe no banco de dados, cria um novo registro
                novoDentista = dentista;
                var dentistaDto = _mapper.Map<DentistaDtos>(novoDentista);
                await _dentista.Create(dentistaDto);
            }
            return novoDentista;
        }

        private async Task<PacienteDentista> SalvarPacienteDentista(Paciente paciente, Dentista dentista)
        {
            var pacienteDentista = new PacienteDentista();
            try {
                pacienteDentista = await _pacienteDentista.GetById(paciente.IdPaciente, dentista.IdDentista);
            }
            catch (Exception)
            {
                pacienteDentista.IdPaciente = paciente.IdPaciente;
                pacienteDentista.IdDentista = dentista.IdDentista;
                var pacienteDentistaDto = _mapper.Map<PacienteDentistaDtos>(pacienteDentista);
                await _pacienteDentista.Create(pacienteDentistaDto);
            }
            return pacienteDentista;
        }
        private async Task<PacienteDados> SalvarDentistas(PacienteDados pacienteDados)
        {
            var novoPacienteDados = new PacienteDados
            {
                Paciente = pacienteDados.Paciente,
                Plano = pacienteDados.Plano,
                Dentistas = new List<Dentista>()
            };

            await _pacienteDentista.DeleteByIdPaciente(pacienteDados.Paciente.IdPaciente);
            
            foreach (var dentista in pacienteDados.Dentistas)
            {                
                var novoDentista = await SalvarDentista(dentista);
                var pacienteDentista = await SalvarPacienteDentista(pacienteDados.Paciente, novoDentista);
                novoPacienteDados.Dentistas.Add(novoDentista);
            }
            return pacienteDados;
        }

        public async Task<IActionResult> ExcluirDentista(int idPaciente, int idDentista)
        {
            var pacienteDados = await BuscarPacienteDados(idPaciente);
            var novoPacienteDados = new PacienteDados
            {
                Paciente = pacienteDados.Paciente,
                Plano = pacienteDados.Plano,
                Dentistas = pacienteDados.Dentistas.Where(x => x.IdDentista != idDentista).ToList()
            };            
            return View("DetalhesPaciente", novoPacienteDados);
        }

        [HttpPost]
        public async Task<IActionResult> SalvarPacienteDados(GerenciarPacientesViewModel.PacienteDados pacienteDados)
        {
            // Valida o estado do modelo
            if (!ModelState.IsValid)
            {
                // Reexibe o formulário com mensagens de erro de validação
                return View("EditPaciente", pacienteDados);
            }

            pacienteDados.Plano = await SalvarPlano(pacienteDados);
            pacienteDados.Paciente = await SalvarPaciente(pacienteDados);
            
            var novoPacienteDados = await SalvarDentistas(pacienteDados);

            // Redireciona para a visão de índice
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Index()
        {
            var viewModel = await CarregarPacientes();
            return View(viewModel);
        }
    }
}
