using DDD.Domain.RH;
using DDD.Domain.UserManagementContext;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.SQLServer
{
    public class SqlContext : DbContext
    {

        //https://balta.io/blog/ef-crud
        //https://jasonwatmore.com/post/2022/03/18/net-6-connect-to-sql-server-with-entity-framework-core

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UniversidadeDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {






            modelBuilder.Entity<Funcionario>()
                .HasMany(e => e.Setores)
                .WithMany(e => e.Funcionarios)
                .UsingEntity<Contratacao>();




            modelBuilder.Entity<User>().UseTpcMappingStrategy();
            modelBuilder.Entity<Funcionario>().ToTable("Funcionario");
            modelBuilder.Entity<Setor>().ToTable("Setor");




        }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Setor> Setores { get; set; }
        public DbSet<Contratacao> Contratacoes { get; set; }
        public DbSet<User> Users { get; set; }



    }
}
