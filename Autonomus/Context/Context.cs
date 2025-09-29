using Autonomus.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autonomus.ContextNameSpace
{
    public class NovoClienteResultado
    {
        [Key]
        public decimal NovoIdCliente { get; set; }
    }
    public class NovoPrestadorResultado
    {
        [Key]
        public decimal NovoIdPrestador { get; set; }
    }

    public class Context : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Prestador> Prestador { get; set; }
        public DbSet<Chat> Chat { get; set; }
        [NotMapped]

        public DbSet<NovoClienteResultado> NovoCliente { get; set; }
        public DbSet<NovoPrestadorResultado> NovoPrestador { get; set; }
        public DbSet<comentario_Cliente> comentario_Cliente { get; set; }
        public DbSet<comentario_Prestador> comentario_Prestador { get; set; }
        public DbSet<NovoIdMensagemResultado> NovoIdMensagem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<comentario_Prestador>()
                        .HasKey(x => x.id_comentario_prestador);
            modelBuilder.Entity<comentario_Prestador>()
                        .ToTable("comentario_Prestador");
            modelBuilder.Entity<Chat>()
                        .HasKey(x => x.id_chat);
            modelBuilder.Entity<Chat>()
                        .ToTable("Chat");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-AF1BB2B;Database=AUTONOMUS;Trusted_Connection=True;Encrypt=false");

        }
    }
    public class comentario_Cliente
    {
        [Key]
        public int id_comentario_cliente { get; set; }
        public string texto_cliente { get; set; }
        public DateTime data_comentario_cliente { get; set; }
        public int id_cliente { get; set; }
       
    }
    public class comentario_Prestador
    {
        [Key]
        public int id_comentario_prestador { get; set; }
        public string texto_prestador { get; set; }
        public DateTime data_comentario_prestador { get; set; }
        public int id_prestador { get; set; }

    }
}
