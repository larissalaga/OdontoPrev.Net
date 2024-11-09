using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplicationOdontoPrev.Dtos;
using WebApplicationOdontoPrev.Models;
using WebApplicationOdontoPrev.Repositories.Interfaces;
using WebApplicationOdontoPrev.ViewModels;

namespace WebApplicationOdontoPrev.Controllers
{
    public class CheckInController : Controller
    {
        private readonly IPacienteRepository _paciente;
        private readonly ICheckInRepository _checkIn;
        private readonly IPerguntasRepository _perguntas;
        private readonly IRespostasRepository _respostas;
        private readonly IPlanoRepository _plano;

        private readonly CheckInViewModel _checkInViewModel;

        public CheckInController(
            IPacienteRepository paciente, 
            ICheckInRepository checkIn, 
            IPerguntasRepository perguntas, 
            IRespostasRepository respostas,
            IPlanoRepository plano
            )
        {
            _paciente = paciente;
            _checkIn = checkIn;
            _perguntas = perguntas;
            _respostas = respostas;
            _plano = plano;
            _checkInViewModel = new CheckInViewModel();
        }
        public async Task<IActionResult> Index(int id)
        {
            var checkInViewModel = new CheckInViewModel();
            var paciente = await _paciente.GetById(id);
            var plano = await _plano.GetById(paciente.IdPlano);

            checkInViewModel.IdPaciente = paciente.IdPaciente;
            checkInViewModel.NmPaciente = paciente.NmPaciente;
            checkInViewModel.NmPlano = plano.NmPlano;
            checkInViewModel.DtCheckIn = DateOnly.FromDateTime(DateTime.Now);
            checkInViewModel.Contador = 1;

            return RedirectToAction("Pergunta", checkInViewModel);
        }
        public async Task<IActionResult> Pergunta(CheckInViewModel checkInViewModel)
        { 
          
            if (checkInViewModel.Contador > 10) // Limita a 10 perguntas respondidas
            {
                return RedirectToAction("Index", "PacienteHome", new { id = checkInViewModel.IdPaciente });
            }

            var pergunta = new Perguntas();
            if (checkInViewModel.Contador == 1)
            {                
                pergunta = await _perguntas.GetProximaPerguntaAsync(0);
            }
            else
            {
                pergunta = await _perguntas.GetProximaPerguntaAsync(checkInViewModel.IdPergunta);             
            }
                        
            if (pergunta == null)
            {
                return RedirectToAction("Index", "PacienteHome", new {id = checkInViewModel.IdPaciente});
            }

            checkInViewModel.IdPergunta = pergunta.IdPergunta;
            checkInViewModel.DsPergunta = pergunta.DsPergunta;            
            checkInViewModel.DsResposta = "";

            return View("Index", checkInViewModel);            
        }

        [HttpPost]
        public async Task<IActionResult> Avancar(CheckInViewModel viewModel)
        {
            /*if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "PacienteHome");
            }*/

            var novaResposta = new RespostasDtos
            {
                DsResposta = viewModel.DsResposta                
            };
            var resposta = await _respostas.Create(novaResposta);
            
            var novoCheckIn = new CheckInDtos
            {
                DtCheckIn = viewModel.DtCheckIn,
                IdPaciente = viewModel.IdPaciente,
                IdPergunta = viewModel.IdPergunta,
                IdResposta = resposta.IdResposta
            };
            await _checkIn.Create(novoCheckIn);
            
            viewModel.Contador += 1;

            return RedirectToAction("Pergunta", viewModel);
        }
    }
}
