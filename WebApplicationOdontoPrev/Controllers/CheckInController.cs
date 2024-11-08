using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplicationOdontoPrev.Dtos;
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
        public async Task<IActionResult> Pergunta(int id, int cont = 1)
        {          
            var paciente = await _paciente.GetById(id);
            var plano = await _plano.GetById(paciente.IdPlano);
            //var checkIns = await _checkIn.GetByIdPaciente(paciente.IdPaciente);

            if (cont > 5)
            {
                return RedirectToAction("Index", "Home");
            }
            
            var perguntaAleatoria = await _perguntas.GetPerguntaAleatoriaAsync();

            if (perguntaAleatoria == null)
            {
                return RedirectToAction("SemPerguntas");
            }

            var _checkInViewModel = new CheckInViewModel
            {
                IdPergunta = perguntaAleatoria.IdPergunta,
                DsPergunta = perguntaAleatoria.DsPergunta,
                Contador = cont
                
            };
            return View("Index",_checkInViewModel);            
        }

        [HttpPost]
        public async Task<IActionResult> Avancar(CheckInViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CheckIn",viewModel);
            }
            var novaResposta = new RespostasDtos
            {
                DsResposta = viewModel.DsResposta
            };
            var resposta = await _respostas.Create(novaResposta);
            viewModel.DtCheckIn = DateOnly.FromDateTime(DateTime.Now);
            

            var novoCheckIn = new CheckInDtos
            {
                DtCheckIn = viewModel.DtCheckIn,
                IdPaciente = viewModel.IdPaciente,
                IdPergunta = viewModel.IdPergunta,
                IdResposta = viewModel.IdResposta
            };
            await _checkIn.Create(novoCheckIn);

            return RedirectToAction("Pergunta", new { cont = viewModel.Contador + 1 });
        }
    }
}
