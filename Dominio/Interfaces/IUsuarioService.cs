using CadastraApi.Dominio.DTOs;
using CadastraAPI.Models;

namespace CadastraAPI.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> AdicionarUsuarioAsync(UsuarioDTO usuarioDTO);
        Task EditarUsuarioAsync(int Id, UsuarioDTO usuarioDTO);
        Task ExcluirUsuarioAsync(int id);
        Task InativarUsuarioAsync(int Id);
        Task<Usuario> ConsultarUsuarioAsync(int id);
        Task<List<Usuario>> ConsultarUsuarioPorPerfil(string perfil);
        Task<List<Usuario>> ConsultarTodosUsuariosAsync();
    }
}