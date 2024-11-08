using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationOdontoPrev.Dtos
{
    public class RespostasDtos
    {
        [Required]
        [MaxLength(400)]
        public string DsResposta { get; set; } = string.Empty;
    }
}
