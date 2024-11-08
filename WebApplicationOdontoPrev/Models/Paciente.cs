using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationOdontoPrev.Models
{
    [Table("T_OPBD_PACIENTE")]
    public class Paciente
    {
        [Key]
        [Required]
        [Column("id_paciente")]
        //[MaxLength(20)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPaciente { get; set; }
        
        [Required]
        [Column("nm_paciente")]
        [MaxLength(100)]
        public string NmPaciente { get; set; } = string.Empty;

        [Required]
        [Column("dt_nascimento")]
        [DataType(DataType.Date)]
        public DateOnly DtNascimento { get; set; }

        [Required]
        [Column("nr_cpf")]
        [MaxLength(11)]
        public string NrCpf { get; set; } = string.Empty;

        [Required]
        [Column("ds_sexo")]
        [MaxLength(1)]
        public string DsSexo { get; set; } = string.Empty;

        [Required]
        [Column("nr_telefone")]
        [MaxLength(30)]
        public string NrTelefone { get; set; } = string.Empty;
        
        [Required]
        [Column("ds_email")]
        [EmailAddress]
        [MaxLength(70)]
        public string DsEmail { get; set; } = string.Empty;                 

        [Required]
        [ForeignKey("Plano")]
        //[MaxLength(20)]
        public int IdPlano { get; set; }
        public Plano? Plano { get; set; }
    }
}