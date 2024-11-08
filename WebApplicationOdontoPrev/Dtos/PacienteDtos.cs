﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplicationOdontoPrev.Models;

namespace WebApplicationOdontoPrev.Dtos
{
    public class PacienteDtos
    {
        [Required]
        [MaxLength(100)]
        public string NmPaciente { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateOnly DtNascimento { get; set; }

        [Required]
        [MaxLength(11)]
        public string NrCpf { get; set; } = string.Empty;

        [Required]
        [MaxLength(1)]
        public string DsSexo { get; set; } = string.Empty;

        [Required]
        [MaxLength(30)]
        public string NrTelefone { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(70)]
        public string DsEmail { get; set; } = string.Empty;

        [Required]
        [ForeignKey("Plano")]
        [MaxLength(20)]
        public int IdPlano { get; set; }
        public Plano? Plano { get; set; }
    }
}
