namespace WebApplicationOdontoPrev.ViewModels
{
    public class CheckInViewModel
    {
        public int IdPaciente { get; set; }
        public string NmPaciente { get; set; } = string.Empty;
        public string NmPlano { get; set; } = string.Empty;
        public int IdCheckIn { get; set; }
        public DateOnly DtCheckIn { get; set; }
        public int IdExtratoPontos { get; set; }
        public int NrNumeroPontos { get; set; }
        public string DsMovimentacao { get; set; } = string.Empty;  
        public DateOnly DtExtrato { get; set; }
        public int IdPergunta { get; set; }
        public string DsPergunta { get; set; } = string.Empty;
        public int IdResposta { get; set; }
        public string DsResposta { get; set; } = string.Empty;
        public int Contador { get; set; }
    }
}
