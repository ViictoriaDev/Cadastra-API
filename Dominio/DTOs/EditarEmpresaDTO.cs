
namespace CadastraApi.Dominio.DTOs
{
    public class EditarEmpresaDTO
    {
        public required string NomeFantasia { get; set; }
        public required string RazaoSocial { get; set; }
        public required string Socio { get; set; }
        public required string TipoEmpresa { get; set; }
    }
}