using CadastraAPI.Db;
using Microsoft.EntityFrameworkCore;
using CadastraAPI.Interfaces;
using CadastraAPI.Dominio.Services;
using CadastraAPI.Models;
using CadastraApi.Dominio.DTOs;

#region Builder Db

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddOpenApi();

builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

var app = builder.Build();
#endregion

#region Adicionar empresa
app.MapPost("/empresas", async (IEmpresaService empresaService, EmpresaDTO empresaDTO) =>
{
    try
    {
        var empresa = await empresaService.AdicionarEmpresaAsync(empresaDTO);
        return Results.Created($"/empresas/{empresa.Id}", empresa);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});
#endregion

#region Consultar empresa por tipo
app.MapGet("/empresas/tipo/{tipoEmpresa}", async (IEmpresaService empresaService, string tipoEmpresa) =>
    await empresaService.ConsultarEmpresaPorTipoAsync(tipoEmpresa));
#endregion

#region Consultar empresa por id
app.MapGet("/empresas/{id}", async (IEmpresaService empresaService, int id) =>
{
    try
    {
        var empresa = await empresaService.ConsultarEmpresaAsync(id);
        return Results.Ok(empresa);
    }
    catch (Exception ex)
    {
        return Results.NotFound(ex.Message);
    }
});
#endregion

#region Consultar todas as empresas
app.MapGet("/empresas", async (IEmpresaService empresaService) =>
await empresaService.ConsultarTodasEmpresasAsync());
#endregion 

#region Editar empresa
app.MapPut("/empresas/{id}", async (IEmpresaService empresaService, int id, EditarEmpresaDTO dto) =>
{
    try
    {
        await empresaService.EditarEmpresaAsync(id, dto);
        return Results.Ok();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});
#endregion

#region Inativar empresa
app.MapPatch("/empresas/{id}/inativar", async (IEmpresaService empresaService, int id) =>
{
    try
    {
        await empresaService.InativarEmpresaAsync(id);
        return Results.NoContent();
    }
    catch (Exception ex)
    {
        return Results.NotFound(ex.Message);
    }
});
#endregion

#region Excluir empresa
app.MapDelete("/empresas/{id}", async (IEmpresaService empresaService, int id) =>
{
    try
    {
        await empresaService.ExcluirEmpresaAsync(id);
        return Results.NoContent();
    }
    catch (Exception ex)
    {
        return Results.NotFound(ex.Message);
    }
});
#endregion

#region Cadastrar usuário
app.MapPost("/usuarios", async (IUsuarioService usuarioService, UsuarioDTO usuarioDTO) =>
{
    try
    {
        var usuario = await usuarioService.AdicionarUsuarioAsync(usuarioDTO);
        return Results.Created($"/usuarios/{usuario.Id}", usuario);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});
#endregion

#region Consultar usuário por id
app.MapGet("/usuarios/{id}", async (IUsuarioService usuarioService, int id) =>
{
    try
    {
        var usuario = await usuarioService.ConsultarUsuarioAsync(id);
        return Results.Ok(usuario);
    }
    catch (Exception ex)
    {
        return Results.NotFound(ex.Message);
    }
});
#endregion

#region Consultar usuários
app.MapGet("/usuarios", async (IUsuarioService UsuarioService) =>
    await UsuarioService.ConsultarTodosUsuariosAsync());
#endregion

#region Consultar usuários por perfil
app.MapGet("/usuarios/tipoPerfil/{perfil}", async (IUsuarioService UsuarioService, string perfil) =>
    await UsuarioService.ConsultarUsuarioPorPerfil(perfil));
#endregion

#region Editar usuário
app.MapPut("/usuarios/{id}", async(IUsuarioService UsuarioService, int id, UsuarioDTO usuarioDTO) =>
{
    try
    {
        await UsuarioService.EditarUsuarioAsync(id, usuarioDTO);
        return Results.Ok();
    }
    catch (KeyNotFoundException ex)
    {
        return Results.NotFound(ex.Message);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(ex.Message);
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message, statusCode: 500);
    }
});
#endregion

#region Inativar Usuário
app.MapPatch("/usuarios/{id}/inativar", async (IUsuarioService UsuarioService, int id) =>
{
    try
    {
        await UsuarioService.InativarUsuarioAsync(id);
        return Results.NoContent();
    }
    catch (Exception ex)
    {
        return Results.NotFound(ex.Message);
    }
});
#endregion

#region Excluir usuário
app.MapDelete("/usuarios/{id}", async (IUsuarioService usuarioService, int id) =>
{
    try
    {
        await usuarioService.ExcluirUsuarioAsync(id);
        return Results.NoContent();
    }
    catch (Exception ex)
    {
        return Results.NotFound(ex.Message);
    }
});
#endregion


app.UseSwagger(); 
app.UseSwaggerUI();


app.Run();