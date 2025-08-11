
using CadastraApi.Dominio.DTOs;
using CadastraAPI.Db;
using CadastraAPI.Interfaces;
using CadastraAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastraAPI.Dominio.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _context;

        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> AdicionarUsuarioAsync(UsuarioDTO usuarioDTO)
        {
            var usuario = new Usuario
            {
                Nome = usuarioDTO.Nome,
                CPF = usuarioDTO.CPF,
                Perfil = usuarioDTO.Perfil,
                EmpresaId = usuarioDTO.EmpresaId
            };

            var cpfExistente = await _context.Usuarios.AnyAsync(u => u.CPF == usuario.CPF && u.EmpresaId == usuario.EmpresaId);
            if (cpfExistente)
                throw new Exception("Já existe um usuário com esse CPF!");

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task EditarUsuarioAsync(int id, UsuarioDTO usuarioDTO)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                throw new Exception("Usuário não encontrado!");
            usuario.Nome = usuarioDTO.Nome;
            usuario.CPF = usuarioDTO.CPF;
            usuario.Perfil = usuarioDTO.Perfil;
            usuario.EmpresaId = usuarioDTO.EmpresaId;

            await _context.SaveChangesAsync();
        }

        public async Task ExcluirUsuarioAsync(int id)
        {
            var usuarioExistente = await _context.Usuarios.FindAsync(id);
            if (usuarioExistente == null)
                throw new Exception("Usuário não encontrado!");

            _context.Usuarios.Remove(usuarioExistente);
            await _context.SaveChangesAsync();
        }

        public async Task InativarUsuarioAsync(int id)
        {
            var usuarioExistente = await _context.Usuarios.FindAsync(id);
            if (usuarioExistente == null)
                throw new Exception("Usuário não encontrado!");

            usuarioExistente.Ativo = false;
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> ConsultarUsuarioAsync(int id)
        {
            var usuarioExistente = await _context.Usuarios.FindAsync(id);
            if (usuarioExistente == null)
                throw new Exception("Usuário não encontrado");

            return usuarioExistente;
        }

        public async Task<List<Usuario>> ConsultarUsuarioPorPerfil(string perfil)
        {
            var usuarios = await _context.Usuarios
                .Where(u => u.Perfil == perfil)
                .ToListAsync();

            return usuarios;
        }

        public async Task<List<Usuario>> ConsultarTodosUsuariosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }
    }
}