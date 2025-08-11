using System;
using CadastraAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace CadastraAPI.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Empresa>().HasMany(e => e.Usuarios)
            .WithOne(u => u.Empresa)
            .HasForeignKey(u => u.EmpresaId)
            .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Empresa>().HasData(
                new Empresa
                {
                    Id = 1,
                    NomeFantasia = "Empresa Exemplo",
                    RazaoSocial = "Empresa Exemplo LTDA",
                    CNPJ = "12.345.678/0001-90",
                    Endereco = "Rua da Praça, 120",
                    Socio = "Victória Nascimento",
                    TipoEmpresa = "LTDA"
                }
            );
        }
    }
}