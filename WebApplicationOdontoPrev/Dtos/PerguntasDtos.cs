using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationOdontoPrev.Dtos
{
    public class PerguntasDtos
    {
        [Required]
        [MaxLength(300)]
        public string DsPergunta { get; set; } = string.Empty;
    }
}
