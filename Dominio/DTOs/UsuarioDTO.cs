using System;
using System.ComponentModel.DataAnnotations;

namespace CadastraApi.Dominio.DTOs
{
    public class UsuarioDTO
    {
        public required string Nome { get; set; }
        public required string CPF { get; set; }
        public required string Perfil { get; set; }
        public required int EmpresaId { get; set; }
    }
}