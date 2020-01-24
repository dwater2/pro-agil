using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;
/*
Faltam Instalar os pacotes:
- Microsoft.EntityFrameworkCore;
- Microsoft.EntityFrameworkCore.Sqlite;

Rodar o seguite comando:
- C:\net\ProAgil\ProAgil.Repository> dotnet ef --startup-project ..\ProAgil-AP migration add init 
*/
namespace ProAgil.Repository
{
    public class ProAgilContext : DbContext
    {
        public ProAgilContext(DbContextOptions<ProAgilContext> options) : base (options)
        {
        }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; } 
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; } 
        public DbSet<Lote> Lotes { get; set; } 
        public DbSet<RedeSocial> RedeSociais { get; set; }  

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<PalestranteEvento>()
            .HasKey(PE => new {PE.EventoId, PE.PalestranteId});
            
        }
    }
}