using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplicationOdontoPrev.Repositories.Interfaces;
using WebApplicationOdontoPrev.ViewModels;
using System.Linq;
using static WebApplicationOdontoPrev.ViewModels.HistoricoCheckInsViewModel;

namespace WebApplicationOdontoPrev.Controllers
{
    public class HistoricoCheckInsController : Controller
    {
        private readonly ICheckInRepository _checkIn;
        private readonly IPacienteRepository _paciente;
        private readonly IPlanoRepository _plano;
        private readonly IPerguntasRepository _perguntas;
        private readonly IRespostasRepository _respostas;

        private HistoricoCheckInsViewModel _historicoCheckInsViewModel;

        public HistoricoCheckInsController(
            ICheckInRepository checkIn,
            IPacienteRepository paciente,
            IPlanoRepository plano,
            IPerguntasRepository perguntas,
            IRespostasRepository respostas
            )
        {
            _checkIn = checkIn;
            _paciente = paciente;
            _plano = plano;
            _perguntas = perguntas;
            _respostas = respostas;
        }

        public async Task<IActionResult> Index(int id)
        {
            var paciente = await _paciente.GetById(id);
            var plano = await _plano.GetById(paciente.IdPlano);
            var checkIns = await _checkIn.GetByIdPaciente(paciente.IdPaciente);

            var historicoCheckInItems = new List<HistoricoCheckInsItemViewModel>();

            foreach (var check in checkIns)
            {
                var pergunta = await _perguntas.GetById(check.IdPergunta);
                var resposta = await _respostas.GetById(check.IdResposta);

                var item = new HistoricoCheckInsItemViewModel
                {
                    DtCheckIn = check.DtCheckIn,
                    DsPergunta = pergunta.DsPergunta,
                    DsResposta = resposta.DsResposta
                };

                historicoCheckInItems.Add(item);

            }
            var _historicoCheckInsViewModel = new HistoricoCheckInsViewModel
            {
                IdPaciente = paciente.IdPaciente,
                NmPaciente = paciente.NmPaciente,
                NmPlano = plano.NmPlano,
                PerguntasRespostas = historicoCheckInItems
            };          

            return View(_historicoCheckInsViewModel);
        }
    }
}
