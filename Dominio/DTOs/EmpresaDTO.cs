using System.ComponentModel.DataAnnotations;
using CadastraAPI.Models;

namespace CadastraApi.Dominio.DTOs
{
    public class EmpresaDTO
    {
        public required string NomeFantasia { get; set; }
        public required string RazaoSocial { get; set; }
         public required string CNPJ { get; set; }
        public required string Socio { get; set; }
        public required string TipoEmpresa { get; set; }
        public required string Endereco { get; set; }
    }
}