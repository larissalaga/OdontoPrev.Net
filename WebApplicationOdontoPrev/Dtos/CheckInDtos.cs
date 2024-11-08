using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplicationOdontoPrev.Models;

namespace WebApplicationOdontoPrev.Dtos
{
    public class CheckInDtos
    {
        [Required]
        [DataType(DataType.Date)]
        public DateOnly DtCheckIn { get; set; }

        [Required]
        [ForeignKey("Paciente")]
        [MaxLength(20)]
        public int IdPaciente { get; set; }
        public Paciente? Paciente { get; set; }

        [Required]
        [ForeignKey("Perguntas")]
        [MaxLength(20)]
        public int IdPergunta { get; set; }
        public Perguntas? Perguntas { get; set; }

        [Required]
        [ForeignKey("Resposta")]
        [MaxLength(20)]
        public int IdResposta { get; set; }
        public Respostas? Respostas { get; set; }

    }
}
