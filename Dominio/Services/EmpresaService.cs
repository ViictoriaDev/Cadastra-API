using CadastraAPI.Db;
using CadastraAPI.Interfaces;
using CadastraAPI.Models;
using CadastraApi.Dominio.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CadastraAPI.Dominio.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly AppDbContext _context;

        public EmpresaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Empresa> AdicionarEmpresaAsync(EmpresaDTO empresaDTO)
        {
            var empresa = new Empresa
            {
                NomeFantasia = empresaDTO.NomeFantasia,
                RazaoSocial = empresaDTO.RazaoSocial,
                CNPJ = empresaDTO.CNPJ,
                TipoEmpresa = empresaDTO.TipoEmpresa,
                Socio = empresaDTO.Socio,
                Endereco = empresaDTO.Endereco
            };
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();

            return empresa;

        }
        public async Task EditarEmpresaAsync(int id, EditarEmpresaDTO editarEmpresaDto)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null)
                throw new Exception("Empresa não encontrada!");
            empresa.NomeFantasia = editarEmpresaDto.NomeFantasia;
            empresa.RazaoSocial = editarEmpresaDto.RazaoSocial;
            empresa.TipoEmpresa = editarEmpresaDto.TipoEmpresa;
            empresa.Socio = editarEmpresaDto.Socio;

            await _context.SaveChangesAsync();
        }

        public async Task ExcluirEmpresaAsync(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null)
                throw new Exception("Empresa não encontrada!");

            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();
        }

        public async Task InativarEmpresaAsync(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null)
                throw new Exception("Empresa não encontrada!");

            empresa.Ativo = false;
            await _context.SaveChangesAsync();
        }

        public async Task<Empresa> ConsultarEmpresaAsync(int id)
        {
            var empresa = await _context.Empresas
                .Include(e => e.Usuarios)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (empresa == null)
                throw new Exception("Empresa não encontrada!");

            return empresa;
        }

        public async Task<List<Empresa>> ConsultarEmpresaPorTipoAsync(string tipoEmpresa)
        {
            var empresas = await _context.Empresas
                .Where(e => e.TipoEmpresa == tipoEmpresa)
                .ToListAsync();

            return empresas;
        }

        public async Task<List<Empresa>> ConsultarTodasEmpresasAsync()
        {
            return await _context.Empresas
                .Include(e => e.Usuarios)
                .ToListAsync();
        }
    }
}
