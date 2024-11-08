using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationOdontoPrev.Models;
using WebApplicationOdontoPrev.Repositories.Interfaces;
using WebApplicationOdontoPrev.Dtos;
using WebApplicationOdontoPrev.Data.GeradorDeDadosAleatorios;
using WebApplicationOdontoPrev.Repositories.Implementations;

namespace WebApplicationOdontoPrev.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPacienteRepository _paciente;
        private readonly IDentistaRepository _dentista;
        private readonly IPlanoRepository _plano;
        private readonly IExtratoPontosRepository _extratoPontos;
        private readonly IRaioXRepository _raioX;
        private readonly IAnaliseRaioXRepository _analiseRaioX;
        private readonly ICheckInRepository _checkIn;
        private readonly IPerguntasRepository _perguntas;
        private readonly IRespostasRepository _respostas;
        private readonly IPacienteDentistaRepository _pacienteDentista;

        private GeradorDePacientes _geradorDePacientes;

        public HomeController(ILogger<HomeController> logger, 
            IPacienteRepository paciente, 
            IDentistaRepository dentista,
            IPlanoRepository plano,
            IExtratoPontosRepository extratoPontos,
            IRaioXRepository raioX,
            IAnaliseRaioXRepository analiseRaioX,
            ICheckInRepository checkIn,
            IPerguntasRepository perguntas,
            IRespostasRepository respostas,
            IPacienteDentistaRepository pacienteDentista
            )
        {
            _logger = logger;
            _paciente = paciente;
            _dentista = dentista;
            _plano = plano;
            _extratoPontos = extratoPontos;
            _raioX = raioX;
            _analiseRaioX = analiseRaioX;
            _checkIn = checkIn;
            _perguntas = perguntas;
            _respostas = respostas;
            _pacienteDentista = pacienteDentista;
            _geradorDePacientes = new GeradorDePacientes();
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //public async Task<IActionResult> ImportarPacienteAleatorio()
        //{
        //    var novoPaciente = _geradorDePacientes.GerarPacienteAleatorio();
        //    var pacienteDTO = new PacienteDtos
        //    { 
        //        DsEmail = novoPaciente.DsEmail,
        //        DsSexo = novoPaciente.DsSexo,
        //        DtNascimento = novoPaciente.DtNascimento,
        //        NmPaciente = novoPaciente.NmPaciente,
        //        NrCpf = novoPaciente.NrCpf,
        //        NrTelefone = novoPaciente.NrTelefone,
        //        IdPlano = novoPaciente.IdPlano,
        //    };
        //    await _paciente.Create(pacienteDTO);
        //    return null;
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
