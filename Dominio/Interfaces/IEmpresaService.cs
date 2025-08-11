using CadastraApi.Dominio.DTOs;
using CadastraAPI.Models;

namespace CadastraAPI.Interfaces
{
    public interface IEmpresaService
    {
        Task<Empresa> AdicionarEmpresaAsync(EmpresaDTO empresaDTO);
        Task EditarEmpresaAsync(int id, EditarEmpresaDTO editarEmpresaDto);
        Task ExcluirEmpresaAsync(int id);
        Task InativarEmpresaAsync(int id);
        Task<Empresa> ConsultarEmpresaAsync(int id);
        Task<List<Empresa>> ConsultarEmpresaPorTipoAsync(string tipoEmpresa);
        Task<List<Empresa>> ConsultarTodasEmpresasAsync();

    }
}