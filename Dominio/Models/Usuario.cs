using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CadastraAPI.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        [MaxLength(50)]
        public required string Nome { get; set; }

        [Required]
        [MaxLength(11)]
        public required string CPF { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Perfil { get; set; }

        public int? EmpresaId { get; set; }

        [JsonIgnore]
        public Empresa Empresa { get; set; } = null!;
        public bool Ativo { get; set; } = true;
    }
}