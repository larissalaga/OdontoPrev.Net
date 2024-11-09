using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using WebApplicationOdontoPrev.Models;
using System.Drawing;
using System.Diagnostics.CodeAnalysis;

namespace WebApplicationOdontoPrev.Dtos
{
    public class RaioXDtos
    {
        [Required]
        [MaxLength(200)]
        public string DsRaioX { get; set; } = string.Empty;

        [AllowNull]
        public byte[]? ImRaioX { get; set; } 

        [Required]
        [DataType(DataType.Date)]
        public DateOnly DtDataRaioX { get; set; }

        [Required]
        [Column("id_paciente")]
        [ForeignKey("Paciente")]
        //[MaxLength(20)]
        public int IdPaciente { get; set; }
        public Paciente? Paciente { get; set; }
    }
}
