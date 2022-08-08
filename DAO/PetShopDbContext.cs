using Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DAO
{
    //Install-Package Microsoft.EntityFrameworkCore.SqlServer - DAO
    //Install-Package Microsoft.EntityFrameworkCore.Tools  -  DAO 
    //Install-Package Microsoft.EntityFrameworkCore.Design - PRESENTATION LAYER
    public class PetShopDbContext : DbContext
    {
        //DbSets funcionam como se fossem o DAO do Pet, permitindo realizar todas as operações
        //SQL para a tabela PET mexendo nessa propriedade.
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Definição de connection string e connection resiliance (se a conexão cair, tenta se reconectar até 5 vezes)
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\diego\OneDrive\Documentos\PetShopDatabase.mdf;Integrated Security=True;Connect Timeout=30", options => options.EnableRetryOnFailure(5));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Assembly no contexto do .NET
            //Carrega os map config que tão criado dentro do projeto (assembly) DAO 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }


    }
}