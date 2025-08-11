using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastraAPI.Models
{
    public class Empresa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        [MaxLength(50)]
        public required string NomeFantasia { get; set; }

        [Required]
        [MaxLength(50)]
        public required string RazaoSocial { get; set; }

        [Required]
        [MaxLength(50)]
        public string CNPJ { get; set; } = default!;

        [Required]
        [MaxLength(50)]
        public string Endereco { get; set; } = default!;

        [Required]
        [MaxLength(50)]
        public string Socio { get; set; } = default!;

        [Required]
        [MaxLength(50)]
        public required string TipoEmpresa { get; set; }

        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public bool Ativo { get; set; } = true;
    }
}